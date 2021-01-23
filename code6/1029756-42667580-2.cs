    string folder = DateTime.Now.Date.ToString("yyyy-MM-dd");
    var root = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "Database backup");
    var newFolderPath = Path.Combine(root, folder);
    
    if (!Directory.Exists(newFolderPath))  // if it doesn't exist, create
        Directory.CreateDirectory(newFolderPath);
    
    // Fixed
    string newFileFolderPath = Path.Combine(newFolderPath, "mybackup.sql");
    
    MySqlConnection myCon = frmStudentsSignup.establishConnectionToMysql();
    using (MySqlCommand cmd = new MySqlCommand())
    {
        using (MySqlBackup mb = new MySqlBackup(cmd))
        {
            cmd.Connection = myCon;
            myCon.Open();
            mb.ExportToFile(newFileFolderPath);
            myCon.Close();
        }
    }
