    static private void RenameFiles() {
      images = Directory.GetFiles(sf, "*.gif");
      foreach (string name in images) {
        Console.WriteLine("Working on current file: " + name);
        string newName = name.Replace("radar_temp_directory", String.Empty);
        File.Move(name, newName);
      }
    }
