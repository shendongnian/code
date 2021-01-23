        public static void Ifcondition()
        {            
            string answer,value1;
            Console.Clear();
            Console.WriteLine("Would you like to enter your Name");
       1     answer = Console.ReadLine();             
            if (answer == "Yes")
            {               
                Console.WriteLine("Great!!! - Please enter your Name:");
       2        value1 = Console.ReadLine();
                Console.WriteLine("Have a Great Day - {0}", value1);                
            }
            else
            {
                Console.WriteLine("Bye!!!");
            }
       3     Console.ReadKey()};
