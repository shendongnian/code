    public List<string> GetSubstrings(string toSplit, int maxLength, Graphics graph, Font font)
    {
         List<string> substrings = new List<string>();
         string[] words = toSplit.Split(" ".ToCharArray());
         string oneSub = "";
         foreach (string oneWord in words)
         {
            string temp = oneSub + oneWord + " ";
            if (graph.MeasureString( temp, font).Width > maxLength) 
            {
               substrings.Add(oneSub);
               oneSub = oneWord + " ";
            }
            else
               oneSub = temp;
         }
         substrings.Add(oneSub);
         return substrings;
    }
