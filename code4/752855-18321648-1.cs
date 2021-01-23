    using (FileStream fs = new FileStream(@"C:\file.csv", FileMode.Open, FileAccess.Read, FileShare.None))
    using (StreamReader sr = new StreamReader(fs, Encoding.GetEncoding(1252)))
    {
        if (sr.ReadLine() == null) //Take this out if you don't have a header
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
