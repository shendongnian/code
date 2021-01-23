    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Windows.Forms;
    
    namespace ComboBoxData
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                string conStr = @"Server =.\SQLEXPRESS2014; Database=NORTHWND; User Id=sa; Password=******";
                SqlConnection conn = new SqlConnection(conStr);
                DataSet ds = new DataSet();
                string getEmpSQL = "SELECT E.LastName FROM dbo.Employees E;";
                SqlDataAdapter sda = new SqlDataAdapter(getEmpSQL, conn);
    
                try
                {
                    conn.Open();
                    sda.Fill(ds);
                }catch(SqlException se)
                {
                    MessageBox.Show("An error occured while connecting to database" + se.ToString());
                }
                finally
                {
                    conn.Close();
                }
    
                comboBox1.DataSource = ds.Tables[0];
                comboBox1.DisplayMember = ds.Tables[0].Columns[0].ToString();
            }
        }
    }
