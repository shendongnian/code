       private void Change_Status(string newStatus)
    {
        ReqID0=ViewState["ReqID0"].ToString();
        sqlc4 = new SqlConnection(ConnectionString);
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "UPDATE Request SET Status=@newStatus WHERE ID=@ReqID";
        cmd.Parameters.AddWithValue("@newStatus", newStatus);
        cmd.Parameters.AddWithValue("@ReqID", ReqID0);
        cmd.Connection = sqlc4;
        sqlc4.Open();
        cmd.ExecuteNonQuery();
        sqlc4.Close();       
      }
