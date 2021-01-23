        protected void Button1_Click1(object sender, EventArgs e)
            {
              
                String query = "SELECT * FROM item_list ";
                
                if(chkTitle.Checked)
                query+="WHERE Title like '%" + txtInput.Text + "%'";
                else if(chkAuthor.Checked)
                query+="WHERE Author = '%" + txtInput.Text + "%'";
                else if(chkPublisher.Checked)
                query+="WHERE Publisher = '%" + txtInput.Text + "%'";
        
                //now execute command with  query variable to perform search 
    string connectionString =
                "Provider=Microsoft.Jet.OLEDB.4.0;" +
                "Data Source='C:\\Users\\Mister\\Documents\\Visual Studio 2012\\Project
    \\LibraryQuerySystem\\QuerySystem\\App_data\\items.mdb';";
    
            string queryString = "INSERT INTO item_list VALUES ('" + title + "', '" +
    author + "', '" + publisher + "')";
    
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();
                OleDbCommand command = connection.CreateCommand();
                command.CommandText = queryString;
                // OleDbCommand command = new OleDbCommand(queryString, connection);
                OleDbDataReader reader = command.ExecuteReader();
    
                while (reader.Read())
                {
                  result+="Title = " reader["Title"].ToString()+"  ";
                  result+="Author= " reader["Author"].ToString()+"  ";
                  result+="Publisher= " reader["Publisher"].ToString()+"  ";
                  result+"<br/>";//dd new line
                }
                connection.Close();
    
               //set Session here
               Session["Results"]=result;
               //now redirect
               Response.Redirect("~/SearchPage.aspx");
            }
          
            }
