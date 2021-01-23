    string path = Directory.GetParent(System.Reflection.Assembly.GetExecutingAssembly().Location).FullName;
    string fileName = Path.Combine(path, "test.txt");
    if (!File.Exists(fileName))
    {
        // Create the file.
        using (FileStream fs = File.Create(fileName))
        {
            Byte[] info =
                new UTF8Encoding(true).GetBytes("This is some text in the file.");
            // Add some information to the file.
            fs.Write(info, 0, info.Length);
        }
    }
   
