                Console.WriteLine("");
                Console.WriteLine("You have encountered a simple guard!  He deals 2 damage per attack and has 1 HP.");
                Console.WriteLine("You currently have: " + Program.Inventory);
                Console.WriteLine("Choose a weapon!");
                var input2 = Console.ReadKey();
                
                //Key checker for items
                while(true)
                {
                switch (input2.Key)
                {
                    case ConsoleKey.D1:
                        Console.WriteLine("");
                        if (Items.iniFists == true)
                        {
                            Console.WriteLine("You have attacked with your Fists for 1 DMG!");
                        }else
                        {
                            //this will never run, just a placeholder
                            Console.WriteLine("You Don't have your fists!");
                            switch (input2.Key)
                {
                    case ConsoleKey.D1:
                        Console.WriteLine("");
                        if (Items.iniFists == true)
                        {
                            Console.WriteLine("You have attacked with your Fists for 1 DMG!");
                        }else
                        {
                            //this will never run, just a placeholder
                            Console.WriteLine("You Don't have your fists!");
                        }
                        break;
                    case ConsoleKey.D2:
                        Console.WriteLine("");
                        if (Items.iniLongsword == true)
                        {
                        Console.WriteLine("You have chosen to attack with the Longsword for 2 DMG!");
                        }else
                        {
                            Console.WriteLine("You don't have a longsword!");
                        }
                        break;
                    case ConsoleKey.D3:
                        Console.WriteLine("");
                        if (Items.iniBow == true)
                        {
                            Console.WriteLine("You have chosen to attack with the Bow for 3 DMG!");
                        }
                        else
                        {
                            Console.WriteLine("You don't have a Bow!");
                        }
                        break;
                    case ConsoleKey.D4:
                        Console.WriteLine("");
                        if (Items.iniLightstaff == true)
                        {
                            Console.WriteLine("You have chosen to attack with the Lightstaff for 4 DMG!");
                        }
                        else
                        {
                            Console.WriteLine("You don't have a Lightstaff!");
                        }
                        break;
                    case ConsoleKey.D5:
                        Console.WriteLine("");
                        Console.WriteLine("You can't attack with an Apple!");
                        break;
                    case ConsoleKey.D6:
                        Console.WriteLine("");
                        Console.WriteLine("You can't attack with a Golden Key!");
                        break;
                    case ConsoleKey.D7:
                        Console.WriteLine("");
                        Console.WriteLine("You can't attack with a Steak!");
                        break;
                }
                        }
                        break;
                    case ConsoleKey.D2:
                        Console.WriteLine("");
                        if (Items.iniLongsword == true)
                        {
                        Console.WriteLine("You have chosen to attack with the Longsword for 2 DMG!");
                        }else
                        {
                            Console.WriteLine("You don't have a longsword!");
                        }
                        break;
                    case ConsoleKey.D3:
                        Console.WriteLine("");
                        if (Items.iniBow == true)
                        {
                            Console.WriteLine("You have chosen to attack with the Bow for 3 DMG!");
                        }
                        else
                        {
                            Console.WriteLine("You don't have a Bow!");
                        }
                        break;
                    case ConsoleKey.D4:
                        Console.WriteLine("");
                        if (Items.iniLightstaff == true)
                        {
                            Console.WriteLine("You have chosen to attack with the Lightstaff for 4 DMG!");
                        }
                        else
                        {
                            Console.WriteLine("You don't have a Lightstaff!");
                        }
                        break;
                    case ConsoleKey.D5:
                        Console.WriteLine("");
                        Console.WriteLine("You can't attack with an Apple!");
                        break;
                    case ConsoleKey.D6:
                        Console.WriteLine("");
                        Console.WriteLine("You can't attack with a Golden Key!");
                        break;
                    case ConsoleKey.D7:
                        Console.WriteLine("");
                        Console.WriteLine("You can't attack with a Steak!");
                        break;
                    default:  Console.WriteLine("Invalid Option Qutting loop");
                             return;
                }
                Console.WriteLine("Choose a weapon!");
                var input2 = Console.ReadKey();
                }
