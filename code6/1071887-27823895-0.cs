    string directory = @"C:\CSharpTestFolder";
    if(!Directory.Exists(directory))
        Directory.CreateDirectory(directory);
    string path = Path.Combine(directory, "Test.txt");
    if (!File.Exists(path))
    {
        File.Create(path);
        using (StreamWriter sw = File.CreateText(path))
        {
            sw.WriteLine("The first line!");
        }
    }
    else if (File.Exists(path))
        MessageBox.Show("File with this path already exists.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
