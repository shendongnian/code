            my sample code for edit/update 
            Table Name =StudentFIle
            Fields = id,fname,lname
            
             bool found = false;
              OleDbConnection BOMHConnection = new OleDbConnection(connect);
            string sql = "SELECT * FROM StudentFIle";
            BOMHConnection.Open();
            OleDbCommand mrNoCommand = new OleDbCommand(sql, BOMHConnection);
            OleDbDataReader mrNoReader = mrNoCommand.ExecuteReader();
            while (mrNoReader.Read())
            {
                if (mrNoReader["id"].ToString().ToUpper().Trim() == idtextbox.Text.Trim())
                {
                    mrNoReader.Close();
                    string query = "UPDATE StudentFIle set fname='" +firstnametextbox.Text+ "',lname='"+lastnametextbox.Text+"' where id="+idtextbox.Text+" ";
                    mrNoCommand.CommandText = query;
                    mrNoCommand.ExecuteNonQuery();
                    MessageBox.Show("Successfully Updated");
                
                    found = true;
                    break;
                }
                continue;
            }
            if (found == false)
            {
                MessageBox.Show("Id Doesn't Exist !.. ");
                mrNoReader.Close();
                BOMHConnection.Close();
                idtextbox.Focus();
            }
         
