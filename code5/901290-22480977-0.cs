    StreamReader sr = new StreamReader(strSourcePath);
    StreamWriter swUpdatedFile = new StreamWriter(strSourcePath.Replace(".txt", ".dat"), false, Encoding.GetEncoding(1250));
    while (!sr.EndOfStream)
    {
          string line = sr.ReadLine();
          if (line.Contains("hello world"))
          {
               swUpdatedFile.WriteLine("Hello World!");
    
          }//if
          else 
          { 
               swUpdatedFile.WriteLine(line);
          }
                    
      }//while
