    using (FileStream fs = new FileStream(@"C:\file.csv", FileMode.Open, FileAccess.Read, FileShare.None))
    using (StreamReader sr = new StreamReader(fs, Encoding.GetEncoding(1252)))
    {
        if (sr.ReadLine() == null)
        {
            throw new Exception("Empty file?!");
        }
        
        while (sr.Peek() >= 0)
        {
              String s = sr.ReadLine();
              
              //SPLIT
              //INSERT SQL
        }
    }
