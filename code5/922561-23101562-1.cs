    Console.WriteLine("Enter Something From Keybord");
    var variable = Console.ReadLine();
    int i;
    double d;
    if(Int32.TryParse(variable, out i))
    {
        // Your variable is a valid int and it's value assingned to i.
    }
    if(Double.TryParse(variable, out d))
    {
        // Your variable is a valid double and it's value assingned to d.
    }
