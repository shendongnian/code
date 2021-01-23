    static void Main(string[] args) {
      //String fileName = @"C:\Documents and Settings\9chat73\Desktop\count.txt"; 
      // To search dinamically, just ask for a file:
      Console.WriteLine("Enter a file to search");
      String fileName = Console.ReadLine().Trim(); 
    
      if (File.Exists(fileName)) {
        Console.WriteLine("Enter a word to search");
        String pattern = Console.ReadLine().Trim();
        // Do not forget to escape the pattern! 
        int count = Regex.Matches(File.ReadAllText(fileName), 
                                  Regex.Escape(pattern), 
                                  RegexOptions.IgnoreCase).Count;
     
        Console.WriteLine(count.ToString());
      }
    
      Console.ReadLine();
    }
