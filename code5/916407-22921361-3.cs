    string imageSavePath = @"C:\Users\Me\Desktop\test.png";
    byte[] imageBytes;
    using (var conn = new OleDbConnection(
        @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Data\access.mdb"))
    {
        using (var cmd = new OleDbCommand(
            "SELECT [image] FROM tblImages WHERE id = 1", conn))
        {
            conn.Open();
            imageBytes = (byte[])cmd.ExecuteScalar();
        }
    }
    File.WriteAllBytes(imageSavePath, imageBytes);
