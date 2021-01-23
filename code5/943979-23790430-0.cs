     List<string> lstInput = new List<string>();     
     using (StreamReader reader = new StreamReader(@"testing.asm"))
     {
        string sLine = string.Empty;
        //read one line at a time
        while ((sLine = reader.ReadLine()) != null)
        {
            lstInput.Add(sLine);
        }
     }
     using (StreamWriter writer =  new StreamWriter("output.hack"))
     {
           foreach(string s in lstInput)
           {
               //modify string s into binary
               writer.WriteLine(s);
           }
     }
 
