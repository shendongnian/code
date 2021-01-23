     var dictDSDRecordsByValidCompCode = new Dictionary<int, string>(); // This dictionary will get rid of pipe delimited comp codes, get distinct, and keep cuont of how many DSD records per Comp Code
    
            if (LineToStartOn.pInt > 0)
            {
               using (var sr = new StreamReader("\\rvafiler1\rdc\clients\sams\pif\DSD_Dictionary.txt"))
                {
                    string line = null;
                    int lineNumber = 1;
    
                    // while it reads a key
                    while (!string.IsNullOrEmpty(line = sr.ReadLine()) )
                    {
                        // add the key and whatever it 
                        // can read next as the value
                        dictDSDRecordsByValidCompCode.Add(lineNumber++, line);
                    }
                }
            }
