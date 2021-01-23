    // Some file movement to the desired project folder
    string fileName = Path.GetFileName(this.textBox1.Text);
    string projectFilePath = Path.Combine(projectDir, fileName);
    File.Copy(this.textBox1.Text, projectFilePath);
    
    // Write to database like this - imagepath is VARCHAR type
    string sql = "INSERT INTO imagepathtable (imagepath) VALUES (@filepath)";
    using (var conn = new MySqlConnection(cs))
    {
        conn.Open();
        using (var cmd = new MySqlCommand(sql, conn))
        {
            cmd.Parameters.AddWithValue("@filepath", projectFilePath);
            cmd.ExecuteNonQuery();
        }
    }
