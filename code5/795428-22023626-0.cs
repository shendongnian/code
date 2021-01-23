    using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings("DefaultConnection").ConnectionString)) {
        string queryString = "SELECT AspNetUsers.UserName FROM dbo.AspNetUsers INNER JOIN dbo.AspNetUserRoles ON " + "AspNetUsers.Id=AspNetUserRoles.UserId WHERE AspNetUserRoles.RoleID='" + id + "'";
        SqlCommand command = new SqlCommand(queryString, connection);
        command.Connection.Open();
        List<string> @out = null;
        dynamic reader = command.ExecuteReader();
        while (reader.Read()) {
            if (@out == null) @out = new List<string>();
            @out.Add(reader.GetString(0));
        }
        return @out;
    }
