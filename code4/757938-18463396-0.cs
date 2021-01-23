    void fill_listbox()
        {
           try
            {
            string constring = "datasource=sql2.freesqldatabase.com;port=3306;username=sql217040;password=xxxxx";
            string Query = "select * from sql217040.fakedata ;";
            using(MySqlConnection conDataBase = new MySqlConnection(constring))
            {
                conDataBase.Open();
                using (SqlDataAdapter a = new SqlDataAdapter(Query, conDataBase))
         		{
	        	    DataTable t = new DataTable();
		            a.Fill(t);		    
         		    // Render data onto the screen
	        	    dataGridView1.DataSource = t; // <-- datagridview1 is the gridview i have added
		     }
           }
           }
           catch(Exception ex)
           {
                MessageBox.Show(ex.ToString());
           }
        }
