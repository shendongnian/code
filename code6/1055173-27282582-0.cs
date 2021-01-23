    using (StreamReader sr = new StreamReader(path))
    {
        while (!sr.EndOfStream)
        {
            sr.ReadLine();
         }            
    }
    using (StreamWriter sw  = new StreamWriter(path))
    {              
         sw.WriteLine(s);
               
    }
