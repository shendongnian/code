    public static string[] SplitWithDelimiters(this string source, params char[] delimiters)
    {
         var temp = new List<char>();
         var parts = new List<string>()
         foreach(var c in source)
         {
             if(delimiters.Contains(c))
             {
                 if(temp.Any()) 
                 {
                      parts.Add(new string(temp.ToArray()));
                      temp.Clear();
                 }
                 parts.Add(c.ToString()); 
             }
             else
             {
                 temp.Add(c);
             }
         }
         return parts.ToArray();
    }
