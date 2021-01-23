    Console.Error.WriteLine("Enabled");
    var saved = Console.Error;
    Console.SetError(new NulTextWriter());
    Console.Error.WriteLine("This should not appear");
    Console.SetError(saved);
    Console.Error.WriteLine("Restored");
