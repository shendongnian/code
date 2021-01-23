      // Private field
      private AutoCompleteStringCollection coll = new AutoCompleteStringCollection();
      
      public Form1(){
            InitializeComponent();
            ....
            searchTxtBox.AutoCompleteMode = AutoCompleteMode.Suggest;
            searchTxtBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
      }
    
        void autoComplete()
           {
                col.clear() // Clear older entries
                SqlConnection con = new SqlConnection(@"Data Source=.;Initial Catalog=Cmanager;Integrated Security=True");
                SqlCommand comm = new SqlCommand("Select * from NEWMEMBER", con);
                SqlDataReader reader;
                try
                {
                    con.Open();
                    reader = comm.ExecuteReader();
                    while (reader.Read())
                    {
                        if (nameRadBtn.Checked) 
                        { 
                        string databaseAuto = (reader["Surname"].ToString());
                        coll.Add(databaseAuto);
                        }
                        if (idRadBtn.Checked)
                        {
                            string databaseAuto = (reader["MemberID"].ToString());
                            coll.Add(databaseAuto);
                        }
                        if (deptRadBtn.Checked)
                        {
                            string databaseAuto = (reader["DeptID"].ToString());
                            coll.Add(databaseAuto);
                        }
        
                    }
                    con.Close();
                }
                catch (Exception)
                {
        
                    throw;
                }
            }
        
         private void searchTxtBox_KeyUp(object sender, KeyEventArgs e)
         {
             autoComplete();
             searchTxtBox.AutoCompleteCustomSource = coll;
         }
