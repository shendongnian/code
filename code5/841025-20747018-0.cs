    da.InsertCommand = new OleDbCommand("INSERT INTO UserProfile (UserName) VALUES (@UserName)", conn);
            {
              string usrName = Add_Usertoprof.SelectedRow.Cells[0].Text; //whatever your cell num is 
              da.InsertCommand.Parameters.AddWithValue("@UserName", usrName);
            }
            conn.Open();
    
            da.InsertCommand.ExecuteNonQuery();
    
            conn.Close();
