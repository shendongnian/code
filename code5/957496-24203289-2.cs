    String sql = "Insert Into tblSchool(SchoolName, CreatedBy, CreatedOn) "
               + "values(@Name, @CreatedBy, @CreatedOn)";
    using (var command = new SqlCommand(sql, connection))
    {
        command.Parameters.Add("@Name", SqlDbType.VarChar).Value = name;
        command.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = creator;
        command.Parameters.Add("@CreatedOn", SqlDbType.DateTime).Value = date;
        int results = command.ExecuteNonQuery();
        ...
    }
