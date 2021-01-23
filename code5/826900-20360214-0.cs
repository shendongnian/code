    using (System.IO.StreamReader sr = new System.IO.StreamReader("path"))
    {
        string line = null;
        string prevLine = null;
        while ((line = sr.ReadLine()) != null)
        {
            if (prevLine != null)
            {
                //preform action in previous line now
    
            }
    
            prevLine = line;
        }
    }
