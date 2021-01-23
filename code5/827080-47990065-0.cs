    static void Main(string[] args)
    {
        var menu = new EasyConsole.Menu()
          .Add("foo", () => Console.WriteLine("foo selected"))
          .Add("bar", () => Console.WriteLine("bar selected"));
        menu.Display();
    }
