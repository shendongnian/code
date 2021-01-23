    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Data.SqlClient;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    namespace InvoiceSQL
    {
        public partial class Form1 : Form
        {
    
            private BindingSource masterBindingSource = new BindingSource();
            private BindingSource detailsBindingSource = new BindingSource();
            private BindingSource dg3BindingSource = new BindingSource();
    
            public Form1()
            {
                InitializeComponent();
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                dg1.DataSource = masterBindingSource;
                dg2.DataSource = detailsBindingSource;
                dg3.DataSource = dg3BindingSource;
                getData();
    
                dg1.AutoResizeColumns();
                dg2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dg3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
    
            }
    
            private void getData()
            {
                try
                {
                    //Odredi string za konekciju
                    String connectionString = "Data Source=.;Initial Catalog=AdventureWorksLT2012;Integrated Security=True";
                    //Konektuj se na bazu
                    SqlConnection connection = new SqlConnection(connectionString);
    
                    //Odredi novi dataset
                    DataSet data = new DataSet();
    
                    data.Locale = System.Globalization.CultureInfo.InvariantCulture;
    
                    //Dodaj podatke iz tabele Kupci u DataSet
                    SqlDataAdapter masterDataAdapter = new SqlDataAdapter("exec dbo.uspGetCustomerCompany", connection);
                    masterDataAdapter.Fill(data, "Customers");
    
                    //Dodaj podatke iz tabele Kupci u DataSet
                    SqlDataAdapter detailsDataAdapter = new SqlDataAdapter("exec dbo.uspGetOrdersShort", connection);
                    detailsDataAdapter.Fill(data, "Orders");
    
                    //Dodaj podatke iz tabele Narudzbe u DataSet
                    SqlDataAdapter dg3DataAdapter = new SqlDataAdapter("exec dbo.uspGetOrderDetailsShort", connection);
                    dg3DataAdapter.Fill(data, "OrderItems");
    
                    //Povezi Kupce i Narudzbe
                    DataRelation relation = new DataRelation("CustomerOrders",
                        data.Tables["Customers"].Columns["CustomerID"],
                        data.Tables["Orders"].Columns["CustomerID"]);
                    data.Relations.Add(relation);
    
                    //Vezi dg1 data connector za tabelu Customers
                    masterBindingSource.DataSource = data;
                    masterBindingSource.DataMember = "Customers";
    
                    //Vezi dg2 data connector za dg1 data connector i filtriraj informacije
                    //u dg2 preko DataRelation preko trenutnog reda u dg1.
                    detailsBindingSource.DataSource = masterBindingSource;
                    detailsBindingSource.DataMember = "CustomerOrders";
    
                    //Povezi Narudzbe i Detalje Narudžbi
                    DataRelation relation1 = new DataRelation("OrdersOrderItems",
                        data.Tables["Orders"].Columns["SalesOrderID"],
                        data.Tables["OrderItems"].Columns["SalesOrderID"]);
                    data.Relations.Add(relation1);
    
                    //Vezi dg2 data connector za dg1 data connector i filtriraj informacije
                    //u dg2 preko DataRelation preko trenutnog reda u dg1.
                    dg3BindingSource.DataSource = detailsBindingSource;
                    dg3BindingSource.DataMember = "OrdersOrderItems";
    
                }
    
                catch (SqlException)
                {
                    MessageBox.Show("Nesto nije u redu u zahtijevanju podataka iz baze!");
                }
    
            }
    
        }
    }
