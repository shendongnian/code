    string imagePath = @"C:\Users\Me\Pictures\rubic.png";
    byte[] imageBytes = File.ReadAllBytes(imagePath);
    using (var conn = new OleDbConnection(
        @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Data\access.mdb"))
    {
        using (var cmd = new OleDbCommand(
            "INSERT INTO tblImages ([image], [name]) VALUES (@1, @2)", conn))
        {
            conn.Open();
            cmd.Parameters.AddWithValue("@1", imageBytes);
            cmd.Parameters.AddWithValue("@2", "Rubic's cube");
            cmd.ExecuteNonQuery();
        }
    }
