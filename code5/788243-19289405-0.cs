    StreamReader sr = new StreamReader(@"C:\CSV\test.csv")
    StreamWriter sw = new StreamWriter(@"C:\CSV\testOut.csv")
    while (sr.Peek() >= 0) 
    {
        string line = sr.ReadLine(); 
    
    
    try
    {
           string resultIBAN = client.BBANtoIBAN(row);
           if (resultIBAN != string.Empty)
           {
               line +=";"+ resultIBAN;
           }
           else
           {
                line +=";"+"Accountnumber is not correct.";
           }
          sw.WriteLine(line)
     }
     catch (Exception msg)
     {
         Console.WriteLine(msg);
     }
     }
