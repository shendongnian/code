    string FileToProcess = System.IO.File.ReadAllText(@"up.FolderPath");
          using (StreamReader sr = new StreamReader(FileToProcess))
          {
              while (!sr.EndOfStream)
              {
                    string line = sr.ReadLine();
                    if (line.StartsWith("0"))
                    {
                          continue;
                    }
                    else{
                          //Do stuff here
                    }
              }
         }
