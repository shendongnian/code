     try
        {
        // load csv file
        using (StreamReader file = new StreamReader("file.csv"))
              {
               string line = file.ReadLine();
               List<string> fileList = new List<string>();
               // Do something with the lines from the file until the end of  
               // the file is reached. 
               while (line != null)
               {
        
                  fileList.Add(line);
                   line = file.ReadLine();
        
                }
                foreach (string fileListLine in fileList)
                 {
                    Console.WriteLine(fileListLine);
                 }
               }
        }      
