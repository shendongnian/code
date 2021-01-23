    using (System.IO.StreamReader sr = new System.IO.StreamReader("path"))
    {
        string line = null;
        string prevLine = null;
        while ((line = sr.ReadLine()) != null)
        {
            if (prevLine != null)
            {
                //perform all the actions you wish with the previous line now
            }
    
            prevLine = line;
        }
    }
