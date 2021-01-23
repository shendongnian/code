      public static IEnumerable<string> ReadLines(Stream stream)
      {
         using (var reader = new StreamReader(stream))
         {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
               yield return line;
            }
         }
      }
