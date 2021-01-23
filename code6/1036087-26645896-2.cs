     string str = "ACFT FTT";
     Dictionary<string, string> replacements = new Dictionary<string, string>()
     {
         {"ACFT", "AIRCRAFT"},
         {"FT", "FEET"},
     };
     string[] temp = str.Split(' ');
     string newStr = "";
     for (int i = 0; i < temp.Length; i++)
     {
         try
         {
             temp[i] = temp[i].Replace(temp[i], replacements[temp[i]]);
         }
         catch (KeyNotFoundException e)
         {
             // not found..
         }
         newStr+=temp[i]+" ";
     }
     Console.WriteLine(  newStr);
