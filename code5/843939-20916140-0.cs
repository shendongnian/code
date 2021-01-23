    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using System.Data.SqlClient;
    
    namespace Book
    {
        public partial class frmBook : Form
        {
            SqlConnection con =
                new SqlConnection(@"Data Source=EDIOTH\SQLEXPRESS;
                    Initial Catalog=XXDB; Integrated Security=SSPI");
            SqlCommand cmd;
            public frmBook()
            {
                InitializeComponent();
            }
    
            private void frmBook_Load(object sender, EventArgs e)
            {
                con.Open();
                cmd = new SqlCommand("SELECT min(Book_ID) FROM Book;",con);
                txtID.Text = cmd.ExecuteScalar().ToString();
                cmd = new SqlCommand("SELECT title FROM Book WHERE Book_ID = '" 
                    + txtID.Text + "'", con);
                txtTitle.Text = cmd.ExecuteScalar().ToString();
                con.Close();
                btnSave.Enabled = false;
            }
    
            private void btnNext_Click(object sender, EventArgs e)
            {
                int count = int.Parse(txtID.Text) + 1;
                con.Open();
                cmd = new SqlCommand("SELECT title FROM Book WHERE Book_ID = '"
                    + count.ToString() +"'", con);
                txtTitle.Text = cmd.ExecuteScalar().ToString();
                txtID.Text = count.ToString();
                con.Close();
            }
    
            private void btnNew_Click(object sender, EventArgs e)
            {
                txtID.Text = "";
                txtTitle.Text = "";
                txtAuthor.Text = "";
                btnNew.Enabled = false;
                btnSave.Enabled = true;
            }
    
            private void btnSave_Click(object sender, EventArgs e)
            {
                con.Open();
                cmd = new SqlCommand("INSERT INTO Book (Book_ID, Title, Author) " +
                    "VALUES ('"+ txtID.Text +
                    "','"+ txtTitle.Text +
                    "','"+ txtAuthor.Text +"');", con);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Data saved!");
                btnSave.Enabled = false;
            }
    
            private void btnClose_Click(object sender, EventArgs e)
            {
                this.Close();
            }
        }
    }
