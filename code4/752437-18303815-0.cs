            //Prompt for input
            System.Console.WriteLine( "Please enter the name" );
            System.Console.Write( "Name> " );
            string name = System.Console.ReadLine();
            /*
             *  Notice how I don't load the files here?
             *  If one of the files is 100 MB, your program will use 100 MB of memory and possibly more.
            */
            string text;
            //Display the attributes to the console.
            System.Console.WriteLine( " " );
            // Add a conditional switch statement.
            switch ( name ) // This is similar to using if-else statements.
            {
                case "Jack":
                    text = System.IO.File.ReadAllText( @"D:\Users\Jack\Documents\Test\Jack.txt" );
                    Console.WriteLine( text );
                    
                    break; // This is used to leave the switch statement.
                case "Ken":
                    text = System.IO.File.ReadAllText( @"D:\Users\Jack\Documents\Test\Ken.txt" );
                    Console.WriteLine( text );
                    
                    break;
                case "Wizard":
                    text = System.IO.File.ReadAllText( @"D:\Users\Jack\Documents\Test\Wizard.txt" );
                    Console.WriteLine( text );
                    
                    break;
                default: // This is when the program can't match any values above.
                    Console.WriteLine( "Error! No-one exists with that name!" );
                    break;
            }
