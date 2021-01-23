    static public T GetNumberFromUser<T>(string Info)
    {
        Type t = typeof(T);
        if (t.Equals(typeof(int)) || t.Equals(typeof(double)))
            return (T)GetNumberFromUser2<T>(Info);
        throw new ArgumentException(string.Format("GetNumberFromUser<T> only works with int and double. Type '{0}' is not valid.", t.Name));
    }
    static private object GetNumberFromUser2<T>(string Info)
    {
        object TheDesiredNumber = null;
        Type t = typeof(T);
        while (true)
        {
            Console.Write("Please type " + Info + " : ");
    
            if (t.Equals(typeof(int)))
            {
                int TheDesiredInt;
                if (int.TryParse(Console.ReadLine(), out TheDesiredInt))
                {
                    TheDesiredNumber = TheDesiredInt;
                }
            }
            else if (t.Equals(typeof(double)))
            {
                double TheDesiredDouble;
                if (double.TryParse(Console.ReadLine(), out TheDesiredDouble))
                {
                    TheDesiredNumber = TheDesiredDouble;
                }
            }
    
            if (TheDesiredNumber != null)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(" - " + Info + " is set to " + TheDesiredNumber.ToString() + "!");
                Console.ForegroundColor = ConsoleColor.Gray;
                return TheDesiredNumber;
            }
    
            WrongInput(" - Invalid input!");
        }
    }
