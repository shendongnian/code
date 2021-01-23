    static void Main(string[] args)
    {
      var result = "Überarbeitung der SAV Seite;b.i.b.;;;;PB;".Split(';');
      foreach (var part in result)
      {
        Console.WriteLine(" --> " + part);
      }
      Console.ReadLine();
    }
