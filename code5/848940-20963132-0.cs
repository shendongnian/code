    bool control = true;
    while (control)
    {
        _a = Console.ReadLine();
        if (_a.ToUpper() == "C")
        {
            Console.WriteLine(dick.a);
            control = false;
        }
        if (_a.ToUpper() == "M")
        {
        switch (_a.ToUpper())
            {
                case "C":
                    Console.WriteLine(dick.a);
                    control = false;
                    break;
                case "M":
                     control = false; 
                     Shit();
                    break;
                case "A":
                     control = false;
                     Array();
                     break;
            }
    }
