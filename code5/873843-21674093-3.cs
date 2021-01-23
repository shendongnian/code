    using (SqlConnection connection = new SqlConnection(ConnectionString))
    {
        using (SqlCommand command = new SqlCommand("Insert into Sender(CourierNo,LoginID,SenderName) values (@courierNo, @loginId, @senderName)",connection))
        {
            command.Parameters.Add(new SqlParameter("courierNo", cNo.Text));
            command.Parameters.Add(new SqlParameter("loginId", logID));
            command.Parameters.Add(new SqlParameter("senderName", Name1.Text));
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
