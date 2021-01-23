     while(true)
        {
            int menuChoice;
            string userInput = Console.Readline();
            if(Int32.TryParse(userInput, out menuChoice))
            {
                if(menuChoice >= 1 && menuChoice <= 4)
                   RunCommand(menuChoice);
                else
                   Console.WriteLine("Enter a number between 1-4");
            }
            else
                Console.WriteLine("A number between 1-4 is required!");
    
        }
