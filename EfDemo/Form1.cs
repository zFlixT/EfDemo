using AccesoDatos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EfDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private CustomerRepository cr = new CustomerRepository();
        private void btnObtenerTodos_Click(object sender, EventArgs e)
        {
            var cliente = cr.ObtenerTodos();
            dgvCustomers.DataSource = cliente;
        }

        //Obtener Cliente por ID
        private void btnTodos_Click(object sender, EventArgs e)
        {
            var cliente = cr.ObtenerPorID(tboxObtenerTodos.Text);
            List<Customers> lista1 = new List<Customers> { cliente };
            dgvCustomers.DataSource = lista1;
        }
        private Customers crearCliente() {
            var cliente = new Customers
            {
                CustomerID = txbCustomerID.Text,
                CompanyName = txbCompanyName.Text,
                ContactName = txbContactName.Text,
                ContactTitle = txbContactTitle.Text,
                Address = txbAddress.Text
            };
            return cliente;
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            var cliente = crearCliente();
            var resultado = cr.InsertarCliente(cliente);
            MessageBox.Show($"Se inserto {resultado}");
        }
    }
}
