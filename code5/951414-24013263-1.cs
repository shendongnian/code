     int userID;
     if(!Int32.TryParse(txtUserID.Text, out userID))
     {
          MessageBox.Show("Invalid User ID number");
          return;
     }
     using(SqlCeConnection cn = new SqlCeConnection(@"Data Source = D:\Database\Training.sdf"))
     using(SqlCeCommand cmd = new SqlCeCommand("SELECT UserName from Users WHERE UserID=@id;", cn))
     {
         cn.Open();
         cmd.Parameters.AddWithValue("@id", userID);
         object result = cmd.ExecuteScalar();
         if(result != null)
             TrainerNameBox.Text = result.ToString();
         else
             MessageBox.Show("No user for ID=" + userID.ToString());
     }
