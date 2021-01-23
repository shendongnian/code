    class Program
    {
      [STAThread]
      public static void Main(string[] args)
      {
        BrowserControl browser = new BrowserControl();
        browser.PrintHelpPage();
        Console.ReadKey();
      }
    }
