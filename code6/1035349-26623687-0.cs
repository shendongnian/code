         SqlConnection conn = new SqlConnection("ConnectionString");
         conn.Open(); // Make sure connection is open.
         string strQuery = "SELECT MachID, EmpCode, FROM LeaveApply where MachID='" + selectedItem + "'";
         SqlCommand cmd = conn.CreateCommand();
         cmd.CommandText = strQuery;
         SqlDataAdapter sda = new SqlDataAdapter(cmd);
         DataTable dt = new DataTable();
         sda.Fill(dt);
