    public static string[] SplitLine(string str)
    {
         string[] s = new string[7] { 
             str.Substring(0, 3),
             str.Substring(3, 15),
             str.Substring(18, 9),
             str.Substring(27, 9),
             str.Substring(32, 5),
             str.Substring(37, 8),
             str.Substring(45, 8)
         };
         return s;
     }
