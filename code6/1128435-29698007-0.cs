    public static void Main(string[] args)
        {
          string[] test = { "value1", "value2", "value3" };
          string resultString = string.Empty;
          foreach (String s in test)
          {
              resultString += String.Format("%'{0}'%, ", s);
          }
          Console.WriteLine(resultString);
          Console.ReadLine();         
        }
