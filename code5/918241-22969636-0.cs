        public static void Main(string[] args)
        {
           string input = "99,999 ABC XYZ";
           var chars = input.ToCharArray().ToList();
           var builder = new StringBuilder();
           foreach (var character in chars)
           {
               if (char.IsNumber(character))
                   builder.Append(character); 
           }
           int result = 0;
           int.TryParse(builder.ToString(), out result);
           Console.WriteLine(result);
           Console.ReadKey();
        }
