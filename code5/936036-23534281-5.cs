    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    
    namespace ConsoleApplication1
    {
      class Program
      {
        static void Main(string[] args)
        {
    
          const string fileName = "temp.txt";
    
          var results = FindInvalidColumns(fileName);
          using (var reader = File.OpenText(fileName))
          {
            while (!reader.EndOfStream)
            {
              var builder = new StringBuilder();
              var line = reader.ReadLine();
              if (line == null) continue;
              var split = line.Split(new[] { "#" }, 0);
    
              for (var i = 0; i < split.Length; i++)
                if (!results.Contains(i))
                  builder.Append(split[i]);
    
              using (var fs = new FileStream("new.txt", FileMode.Append, FileAccess.Write))
              using (var sw = new StreamWriter(fs))
              {
                sw.WriteLine(builder.ToString());
              }
            }
          }
        }
    
        private static List<int> FindInvalidColumns(string fileName)
        {
          var invalidColumnIndexes = new List<int>();
          using (var reader = File.OpenText(fileName))
          {
            while (!reader.EndOfStream)
            {
              var line = reader.ReadLine();
              if (line == null) continue;
    
              var split = line.Split(new[] { "#" }, 0);
              for (var i = 0; i < split.Length; i++)
              {
                if (IsInvalid(split[i]) && !invalidColumnIndexes.Contains(i))
                  invalidColumnIndexes.Add(i);
              }
            }
          }
          return invalidColumnIndexes;
        }
    
        private static bool IsInvalid(string s)
        {
          return false;
        }
      }
    }
