    using(var sw = new StreamWriter(PServer1))
    {
      sw.AutoFlush = true;
    
      while(Condition) // This could be done by analyzing the user's input and looking for something special...
      {
        Console.Write("Enter text: ");
        sw.WriteLine(Console.ReadLine());
      }
    }
