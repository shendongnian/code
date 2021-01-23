       static void Main(string[] args)
        {
            //All of the code starts here. Some call this an 'entry point'.           
            do
            {
                String myString = "Hello world! My name is Graham and I am the developer of this application.";
                Console.WriteLine(myString);
                Console.WriteLine(" ");
                Console.WriteLine("Type 'q' for an explanation of some British slang.");
                Console.WriteLine("Type 'w' for some meta text.");
                Console.WriteLine("Type 'e' for the same compliment printed twice.");
                Console.WriteLine("Type 's' to close.");
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                if (keyInfo.KeyChar == 'q')
                {
                    Console.WriteLine("'Chav' is British slang for 'Council House And Violent', council house meaning a house on rent from the council (They're cheap, which means they're usually associated with poorness) and violent meaning easily angered and vicious.");
                }
                else if (keyInfo.KeyChar == 'w')
                {
                    printSomeTextToScreen();
                }
                else if (keyInfo.KeyChar == 'e')
                {
                    printNiceTextToScreenTwice();
                }
                else if (keyInfo.KeyChar == 's')
                {
                    break;
                }
            }
            while (true);
        }
