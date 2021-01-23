    private void searchbtn_Click(object sender, EventArgs e)
    {
         SqlCeConnection con = new SqlCeConnection(@"Data Source=C:\Users\hry\Documents\Visual Studio 2010\Projects\Kargozini\Kargozini\khadamat.sdf");
    	 
         try
         {
             con.Open();
             string SearchQuerry = "SELECT ID, radif, Name, Type, Description, Price FROM Users WHERE ID = '"+searchtxt.Text+"'" ;
             SqlCeCommand com = new SqlCeCommand(SearchQuerry,con);
    		 
    		 SqlCeDataReader sqlReader = com.ExecuteReader();
    		 
    		 while (sqlReader.Read())
    		{
    			txtID.text = sqlReader.GetValue(0).ToString();
    			txtRadif.text = sqlReader.GetValue(1).ToString();
    			txtName.text = sqlReader.GetValue(2).ToString();
    		}
    		
    		sqlReader.Close();
            com.Dispose();
            con.Close();
         }
         catch (SqlCeException ex)
         {
             MessageBox.Show(ex.Message);
         }
    }
