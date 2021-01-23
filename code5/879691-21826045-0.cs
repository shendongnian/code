    string source_dir = "E:\\Debug\\Vip";
    string destination_dir = "C:\\Vip";
    
    if (!System.IO.Directory.Exists(destination_dir))
    {
        System.IO.Directory.CreateDirectory(destination_dir);
    }
    
    // substring is to remove destination_dir absolute path (E:\).
    
    // Create subdirectory structure in destination    
    foreach (string dir in Directory.GetDirectories(source_dir, "*", System.IO.SearchOption.AllDirectories))
    {
        Directory.CreateDirectory(Path.Combine(destination_dir,dir.Substring(source_dir.Length));
    
    }
    
    foreach (string file_name in Directory.GetFiles(source_dir, "*.*", System.IO.SearchOption.AllDirectories))
    {
        File.Copy(file_name, Path.Combine(destination_dir, file_name.Substring(source_dir.Length), true));
    } 
               
