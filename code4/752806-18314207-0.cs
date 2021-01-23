    // You can use replace windows authentication with any user credentials who has proper permissions.
    using (SqlConnection connection = new SqlConnection(@"server=(local);database=master;Integrated Security=SSPI"))
    {
        connection.Open();
        using (SqlCommand command = connection.CreateCommand())
        {
            command.CommandText = "CREATE DATABASE [XYZ]";
            command.ExecuteNonQuery();
        }
    }
    // Quering the XYZ database created
    using (SqlConnection connection = new SqlConnection(@"server=(local);database=XYZ;Integrated Security=SSPI"))
    {
        connection.Open();
        using (SqlCommand command = connection.CreateCommand())
        {
            command.CommandText = "select * from sys.objects";
            ...
        }
    }
