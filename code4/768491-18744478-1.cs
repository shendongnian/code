    using System.Text.RegularExpressions
    namespace ConsoleApplication1
    {
      class Program
      {
        static void Main(string[] args)
        {
          string content = "Hi:Mr. Title:Sample Email:default123_11@gmail.com";
          // Here we call Regex.Match.
          Match match = Regex.Match(content, @"Email:([a-zA-Z0-9@._]*)",
                RegexOptions.IgnoreCase);
          // Here we check the Match instance.
          if (match.Success)
          {
            // Finally, we get the Group value and display it.
            string key = match.Groups[1].Value;
            Console.WriteLine(key);
          }
          Console.ReadKey();
        }
      }
    }
