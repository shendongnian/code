    using System;
    using System.Text.RegularExpressions;
    namespace myapp
    {
      class Class1
        {
          static void Main(string[] args)
            {
              String sourcestring = "source string to match with pattern";
              Regex re = new Regex(@"(\b(8|08|10):\d{2}-[a-zA-Z]{2}-\d{3,5}\b)",RegexOptions.IgnoreCase);
              Match m = re.Match(sourcestring);
              for (int gIdx = 0; gIdx < m.Groups.Count; gIdx++)
                {
                  Console.WriteLine("[{0}] = {1}", re.GetGroupNames()[gIdx], m.Groups[gIdx].Value);
                }
            }
        }
    }
