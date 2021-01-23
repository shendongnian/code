    int ProductID;    
    using (StreamReader sr = new StreamReader(fakeFileToProcess))
    {
        while (!sr.EndOfStream)
        {
            string line = sr.ReadLine();
    
            if (line.StartsWith("1,"))
            {
                string num = line.Split(',')[1].Trim();
                if(int.TryParse(str,out ProductID)
                {
                    //parsing is successful, now ProductID contains int value (103)
                }    
            }
    
            if (line.StartsWith("25"))
            {
                continue;
            }
        }
    }
