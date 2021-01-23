    public List<FileDetails> FilesInfo()
    {
    string userName = HttpContext.Current.User.Identity.Name;
    List<FileDetails> FileDetailsList = new List<FileDetails>();
    using (SqlConnection connection = new SqlConnection(Common.ConnectionString))
    {
        using (SqlCommand cmd = new SqlCommand("SELECT FileName,FileDescription,FileLocation FROM Files WHERE UserName=@UserName"))
        {
            cmd.Parameters.AddWithValue("UserName", userName);
            cmd.Connection = connection;
            connection.Open();
            using(SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    FileDetails f = new FileDetails();
                    f.FileName = reader["FileName"].ToString();
                    f.FileDescription = reader["FileDescription"].ToString();
                    f.FileLocation = reader["FileLocation"].ToString();
                    FileDetailsList.Add(f);
                }
            }
        }
    }
    return FileDetailsList;
    }
