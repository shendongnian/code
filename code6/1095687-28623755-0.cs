    List<string> lines = new List<string>();
    if(File.Exists(path))
    {
        // Read the file and display it line by line.
        System.IO.StreamReader file = new System.IO.StreamReader("c:\\yourtextfilepathhere.txt");
        while((line = file.ReadLine()) != null)
        {
           lines.Add(line);
        }
        file.Close();
    }
    
