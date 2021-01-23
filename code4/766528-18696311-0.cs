    public string GetMaxPixelSubstring(string input, int maxLength, Graphics graph, Font font)
    {
         string part = "";
         foreach (char oneChar in input.ToCharArray())
         {
            string temp = part + oneChar;
    
            if (graph.MeasureString(temp, font).Width > maxLength) 
               return part;
            else
               part = temp;
         }
         return input;
    }
