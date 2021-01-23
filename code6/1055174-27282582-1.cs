    using (StreamReader sr = new StreamReader(path))
    {
        while (!sr.EndOfStream)
        {
            sr.ReadLine();
         }            
    }
    string s;
    using (StreamWriter sw  = new StreamWriter(path))
    {              
         sw.WriteLine(s);
               
    }
