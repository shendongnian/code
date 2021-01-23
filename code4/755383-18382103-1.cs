       public static void Main()
       {
          string pattern = "(0[1-9]|[12][0-9]|3[01])(0[1-9]|1[012])(19|20)[0-9]{2}";
          string str = "D1011608201313";
          Console.WriteLine(Regex.Match(str, pattern).Value);
       }
   
