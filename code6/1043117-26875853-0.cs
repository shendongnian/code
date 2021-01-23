    var a = new A();
    var b = new B();
    Console.WriteLine("Starting value of b.DisplayMode: {0}", b.DisplayMode);
    a.Controls.Add(b);
    a.DisplayMode = DisplayMode.Edit;
    Console.WriteLine("Ending value of b.DisplayMode: {0}", b.DisplayMode);
    // Ouput:
    // Starting value of b.DisplayMode: View
    // Ending value of b.DisplayMode: Edit
