    string path = Path.Combine(Application.StartupPath, "conn.txt");
    string connStrg = System.IO.File.ReadAllText(path);
    using (SqlConnection cnn = new SqlConnection(connStrg))
    {
        ...
    }
