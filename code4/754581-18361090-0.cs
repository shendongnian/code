    string sql = "select * from Bill_Detail where DateTimeofBilling=@QueryDate";
    using (var command = new SqlCommand(sql, conn))
    {
        command.Parameters.Add("@QueryDate", SqlDbType.Date).Value = 
            mcCalendar.SelectionStart.Date;
        // Execute the command
    }
