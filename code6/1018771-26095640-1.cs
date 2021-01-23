    Console.WriteLine("Enabled");
    var saved = Console.Out;
    Console.SetOut(new NulTextWriter());
    Console.WriteLine("This should not appear");
    Console.SetOut(saved);
    Console.WriteLine("Restored");
