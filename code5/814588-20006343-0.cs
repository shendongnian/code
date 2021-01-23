    public MainForm()
        {
           InitializeComponent();
           this.WindowState = FormWindowState.Maximized;
           AppDomain.CurrentDomain.SetData("DataDirectory", @"C:\A\"); 
           myCon = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\database1.mdb"); 
    
        }
    
        OleDbConnection myCon;
        OleDbCommand cmd;
    
        private void btnInsert_Click(object sender, EventArgs e)
        {
    
         myCon.Open();
             OleDbCommand cmd = new OleDbCommand();
             cmd.Connection = myCon;
    
             OleDbCommand cmdCheck = new OleDbCommand();
             cmdCheck.Connection = myCon;   
    
             cmdCheck.CommandText = "SELECT COUNT(*) FROM Details WHERE ID = ?";
             cmdCheck.Parameters.AddWithValue("@ID", txtID.Text);
    
             if (Convert.ToInt32(cmdCheck.ExecuteScalar()) == 0)
             {
         cmd.CommandText = (@"INSERT INTO Details (ID, FirstName)
                           VALUES(@ID, @FirstName)")
    
                 cmd.Parameters.AddWithValue("@ID", txtID.Text);
                 cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
                 cmd.ExecuteNonQuery();
         }
            myCon.Close();
       }
