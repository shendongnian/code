    var a = new A();
    var b = new B();
    Console.WriteLine("Starting value of b Properties:");
    Console.WriteLine(" - b.DisplayMode ... {0}", b.DisplayMode);
    Console.WriteLine(" - b.X ............. {0}", b.X);
    a.Controls.Add(b);
    a.DisplayMode = DisplayMode.Edit;
    Console.WriteLine("Ending value of b Properties:");
    Console.WriteLine(" - b.DisplayMode ... {0}", b.DisplayMode);
    Console.WriteLine(" - b.X ............. {0}", b.X);    
    // Ouput:
    // Starting value of b Properties:
    //  - b.DisplayMode ... View
    //  - b.X ............. 0
    // Ending value of b Properties:
    //  - b.DisplayMode ... Edit
    //  - b.X ............. 10
