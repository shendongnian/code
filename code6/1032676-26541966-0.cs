        static void Main(string[] args)
        {
            Console.WriteLine("Please enter student number:");
            //get the user input
            var number = Console.ReadLine();
            if (number.Length != 5)
            {
                
                Console.WriteLine("Invalid format.");
            }
            else
            {
               
                Console.WriteLine("Yay it works");
            }
            Console.ReadLine();
        }
