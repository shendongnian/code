     public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                String a = TxbName.Text;
                String b = TxbAge.Text ;
                String c = TxbCountry.Text; 
    
                String Constring = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=I:\Applications Coursework\quiz.accdb";
                String cmdinsert = @"INSERT INTO user( user_name,  user_age, user_country) VALUES ( @a, @b, @c )";
                OleDbConnection con = new OleDbConnection (Constring);
                OleDbDataAdapter da = new OleDbDataAdapter();
                OleDbCommand cmd = new OleDbCommand(cmdinsert, con);
    
    
                try
                {
                    da.InsertCommand.Parameters.Add("@a", OleDbType.VarChar, 15);
                    da.InsertCommand.Parameters["a"].Value = TxbName.Text;
                    da.InsertCommand.Parameters.Add("@b", OleDbType.VarChar, 15);
                    da.InsertCommand.Parameters["b"].Value = TxbAge.Text;
                    da.InsertCommand.Parameters.Add("@c", OleDbType.VarChar, 15);
                    da.InsertCommand.Parameters["c"].Value = TxbCountry.Text;
    
                    con.Open();
                    da.InsertCommand.ExecuteNonQuery();
                    MessageBox.Show("Worked");
                    con.Close();
    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
    
    
    
            }
        }
    }
