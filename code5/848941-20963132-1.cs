    bool control = true;
    while (control)
    {
        _a = Console.ReadKey();
        var character = _a.KeyChar.ToString().ToUpper();
        switch (character)
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
