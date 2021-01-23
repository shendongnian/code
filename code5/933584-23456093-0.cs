    using (StreamWriter sw = new StreamWriter(@"C:\temp\test1.txt", false))
    {
         using (StreamReader sr = new StreamReader(@"C:\temp\test.txt"))
         {
              while (sr.Peek() >= 0)
              {
                     var strReadLine = sr.ReadLine().Trim().Replace("\t", "").Replace("\r\n", "");
                     if (!String.IsNullOrWhiteSpace(strReadLine)) 
                     {
                            sw.WriteLine(strReadLine);               
                     }
              }
         }    
    }
