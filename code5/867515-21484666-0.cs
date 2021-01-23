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
        catch (Exception e)
        {
          // Let the user know what went wrong.
           Console.WriteLine("The file could not be read:");
           Console.WriteLine(e.Message);
        }
