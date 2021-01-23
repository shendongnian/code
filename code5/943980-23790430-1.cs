     List<string> lstInput = new List<string>();     
     using (StreamReader reader = new StreamReader(@"input.asm"))
     {
        string sLine = string.Empty;
        //read one line at a time
        while ((sLine = reader.ReadLine()) != null)
        {
            lstInput.Add(sLine);
        }
     }
     using (StreamWriter writer =  new StreamWriter(@"output.hack"))
     {
           foreach(string s in lstInput)
           {
               //remove leading @ sign
               if(s.StartsWith("@"))               
                  s = s.Substring(1);
                   
               int iNumber;
               if(int.TryParse(s, out iNumber))
               {    
                  writer.WriteLine(IntToBinaryString(iNumber));
               }
           }
     }
     
     public string IntToBinaryString(int number)
     {
         const int mask = 1;
         var binary = string.Empty;
         while(number > 0)
         {
             // Logical AND the number and prepend it to the result string
             binary = (number & 1) + binary;
             number = number >> 1;
         }
         return binary;
     }
