    private bool Validate(string studentId, string time)
    {
        DateTime registrationDate;
        if (!DateTime.TryParse(time.Trim(), out registrationDate))
            throw new ArgumentException("Time must be convertible to datetime", "time");
        int id;
        if (!int.TryParse(studentId.Trim(), out id))
            throw new ArgumentException("StudentId must be convertible to Integer", "studentId");
        string sql = @"
            SELECT * FROM tblStudent 
            WHERE   Registeration_Date=?Registeration_Date 
            AND     StudentID=?StudentID 
            ORDER BY date_time desc 
            limit 1";
        using (var msCon = new MySqlConnection("connection-string"))
        using (var da = new MySqlDataAdapter(sql, msCon))
        {
            da.SelectCommand.Parameters.AddWithValue("?Registeration_Date", registrationDate);
            da.SelectCommand.Parameters.AddWithValue("?StudentID", id);
            var table = new DataTable();
            da.Fill(table);
            return table.Rows.Count = 1;
        }
    }
