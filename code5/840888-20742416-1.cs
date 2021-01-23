    string path = @"c:\mytext.txt";
    
    if (File.Exists(path))
    {
        File.Delete(path);
    }
    
    { // Consider File Operation 1
        FileStream fs = new FileStream(path, FileMode.OpenOrCreate);
        StreamWriter str = new StreamWriter(fs);
        str.BaseStream.Seek(0, SeekOrigin.End);
        str.Write("mytext.txt.........................");
        str.WriteLine(DateTime.Now.ToLongTimeString() + " " + 
                      DateTime.Now.ToLongDateString());
        string addtext = "this line is added" + Environment.NewLine;
        str.Flush();
        str.Close();
        fs.Close();
        // Close the Stream then Individually you can access the file.
    }
     
    File.AppendAllText(path, addtext);  // File Operation 2
    
    string readtext = File.ReadAllText(path); // File Operation 3
    
    Console.WriteLine(readtext);
