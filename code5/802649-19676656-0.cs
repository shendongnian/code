    foreach (string file in studentNames)
        {
            tempString = file.ToLower();
            if (inputSel == tempString)
            {
                foundString = true;
            }
        }
    if (!foundString)
        {
            Console.WriteLine("Wrong name entered!");
            Console.WriteLine("Returning to grades menu..");
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
            return;
        }  
