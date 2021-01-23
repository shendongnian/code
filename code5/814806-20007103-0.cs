        while (option != "0")
        {
            Console.WriteLine(@"
            Critter Caretaker
             0 - Quit
              1 - Listen to your critter
              2 - Feed your critter
              3 - Play with your critter
              ");
            if (option == "0")
            {
                Console.WriteLine("Good-bye.");
            }
            if (option == "1")
            {
                newcritter.talk();
            }
             if (option == "2")
            {
                newcritter.PassTime();
            }
            if (option == "3")
            {
                newcritter.mood();
            }
        }
