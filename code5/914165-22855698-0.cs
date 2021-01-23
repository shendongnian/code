    static void Main()
            {
                Console.WriteLine( "To show the menu, enter -99" );
                Console.WriteLine( "Please enter a set of grades. Min 5 grades, Max 15 grades: " );
                List<int> gradesList =new List<int>();
                bool exit=false;
                do
                {
                    int x = 0;
                    int.TryParse( Console.ReadLine(), out x );
                    switch( x )
                    {
                        case -99:
                            exit = true;
                            break;
                        case 0:
                            Console.WriteLine( "Please insert integer values:" );
                            break;
                        default:
                            gradesList.Add( x );
                            break;
                    }
                } while( !exit );
                ShowMenu();
    
            }
            static void ShowMenu()
            {
                bool exit=false;
                do
                {
                    Console.WriteLine( "1. Number of values in the array" );
                    Console.WriteLine( "2. List the values in the array" );
                    Console.WriteLine( "3. Average" );
                    Console.WriteLine( "4. Delete a specific value" );
                    Console.WriteLine( "5. Clear all the values in the array" );
                    Console.WriteLine( "6. Change a specific value" );
                    Console.WriteLine( "7. Exit" );
                    
                    int x = 0;
                    int.TryParse( Console.ReadLine(), out x );
    
                    switch( x )
                    {
                        case 1:
                            //number of values in the array
                            break;
                        case 2:
                            //list of values in the array
                            break;
                        case 3:
                            //average
                            break;
                        case 4:
                            //delete a specific value
                            break;
                        case 5:
                            //clear all values in the array
                            break;
                        case 6:
                            //change a specific value
                            break;
                        case 7:
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("Invalid option");
                            break;
                    }
                } while( !exit );
            }
