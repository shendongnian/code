    string targetDir = "C:\\Users\\Luca\\Desktop\\TestNoah\\TestNoah\\";
    var reader = command.ExecuteReader();
    while (reader.Read())
    {
        byte[] img = (byte[])reader["PublicData"];
        string path = System.IO.Path.Combine(targetDir, string.Format("{0}.jpg", DateTime.Now.ToFileTime()));
        System.IO.File.WriteAllBytes(path, img);
    }
