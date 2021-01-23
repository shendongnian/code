    public static T GetNumberFromUser<T>(string Info)
        where T : struct
    {
        T TheDesiredNumber = default(T);
        while (true)
        {
            Console.Write("Please type " + Info + " : ");
            // this it the key point
            if (Console.ReadLine().TryParse<T>(out TheDesiredNumber)) 
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(" - " + Info + " is set to " + TheDesiredNumber.ToString() + "!");
                Console.ForegroundColor = ConsoleColor.Gray;
                return TheDesiredNumber;
            }
            WrongInput(" - Invalid input!");
    }
