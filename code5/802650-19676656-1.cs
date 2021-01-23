    if(!studentNames.Contains(inputSel, StringComparer.Create(CultureInfo.InvariantCulture, true)))
    {
                Console.WriteLine("Wrong name entered!");
                Console.WriteLine("Returning to grades menu..");
                Console.WriteLine("Press any key to continue.");
                Console.ReadKey();
                return;
    }
