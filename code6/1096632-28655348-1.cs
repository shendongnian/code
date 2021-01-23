    using (SqlConnection con = new SqlConnection(strConnString))
    {
        using (SqlCommand cmd = new SqlCommand())
        {
            cmd.Connection = con;
            cmd.Connection.Open();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = @"select DATEDIFF(minute, Min(FullDatetime), Max(FullDatetime)) / 60.0 as hours                 
            from   myTable
            where userid = @UserID
            and DT_Submitted = (select CAST(FLOOR( CAST( GETDATE() AS FLOAT ) )AS DATETIME))
            and Checked = 1";
            cmd.Parameters.AddWithValue("@UserID", tempUser.ToString());
            
            var result = cmd.ExecuteScalar();
            var hours = result != null ? (decimal)result : Decimal.Zero;
            lblHours.Text = hours.ToString("0.#")  + " Hours";
        }
    }
