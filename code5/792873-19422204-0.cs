    void Main()
    {
      CreateEmail(new EmailOptions());
    }
    
    private void CreateEmail(EmailOptions options)
    {
      ParameterGuard.ThrowIfNullOrEmpty(options.To, "To");
    }
    
    public static class ParameterGuard
    {
          public static void ThrowIfNullOrEmpty<T>(T enumerable, string argName) 
            where T : IEnumerable
          {
              Console.Write("Generic Version");
          }
      
          public static void ThrowIfNullOrEmpty(string arg, string argName)
          {
              Console.Write("String Version");
          }
    }
    
    public class EmailOptions
    {
        public List<string> To { get; set; }
    }
