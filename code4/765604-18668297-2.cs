     Load(string filepath)
     {
         try
         {
             string[] lines = File.ReadAllLines(filepath);
             foreach (string line in lines)
             {
                 string[] tokens = line.Split(';');
                 if (tokens.Length != 3)
                    // error
                 int isd;
                 if (!int.TryParse(tokens[0], out isd))
                    //error, wasn't an int
                 buetcher.Add(new Buch(isd, tokens[1], tokens[2]);
             }
                                
         {
         catch
         {
             throw new Exception("umwandlung fehlgeschlagen");
         }
         
     }
