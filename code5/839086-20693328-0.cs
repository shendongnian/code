       var key = Console.ReadKey();
       if (key.KeyChar.ToString() == "y")
       {
           Console.WriteLine("-- Yes!");
           Console.ReadKey();
       }
       else if (key.KeyChar.ToString() == "n")
       {
           Console.WriteLine("-- No!");
           Console.ReadKey();
       }
       else
       {
           Console.WriteLine("-- That isn't an option!");
           Console.ReadKey();
       }
