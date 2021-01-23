    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    
    namespace ConsoleApplication1
    {
      class Program
      {
        static void Main(string[] args)
        {
          var builder = new StringBuilder();
          var reader = new StringReader(DataResource.data);
          {
            var results = FindInvalidColumns(reader);
            while (reader.Peek() != -1)
            {
              var line = reader.ReadLine();
              if (line == null) continue;
              var split = line.Split(new[] { "#" }, 0);
    
              for (var i = 0; i < split.Length; i++)
                if (!results.Contains(i))
                  builder.Append(split[i]);
              
              builder.AppendLine();
    
            }
          }
          var result = builder.ToString();
          var yourPath = string.Empty;
          File.WriteAllText(yourPath, result);
        }
    
        private static List<int> FindInvalidColumns(TextReader reader)
        {
          var invalidColumnIndexes = new List<int>();
          while (reader.Peek() != -1)
          {
            var line = reader.ReadLine();
            if (line == null) continue;
    
            var split = line.Split(new[] {"#"}, 0);
            for (var i = 0; i < split.Length; i++)
            {
              if (IsInvalid(split[i]) && !invalidColumnIndexes.Contains(i))
                invalidColumnIndexes.Add(i);
            }
          }
          return invalidColumnIndexes;
        }
    
        private static bool IsInvalid(string s)
        {
          throw new NotImplementedException();
        }
      }
    }
