        Console.Write("Input  employee first name: ");
        var s = new StringBuilder();
        do
        {
            var key = Console.ReadKey(true);
            if (key.KeyChar == '\r')
                break;
            if (char.IsLetter(key.KeyChar))
            {
                Console.Write(key.KeyChar);
                s.Append(key.KeyChar);
            }
        } while (true);
        Console.WriteLine();
        Console.WriteLine( "You typed " + s.ToString());
