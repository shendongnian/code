    var writer = new MyWriter(Console.Out);
    Console.SetOut(writer);
    Console.WriteLine("Hello world");
    Console.WriteLine("Bye!");
    var lines = writer.GetLines();
