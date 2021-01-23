    public static bool primeNumber ()
    {
        Console.Write ("Please enter a number to see if it is a prime number: ");
        int num = int.Parse (Console.ReadLine ());
        if (num % 2 == 0)
            return false;
        else if (num % 5 == 0)
            return false;
        else {
            for (int i = 3; i < num / 2; i += 2)
            {
                if (num % i == 0)
                    return false;
            }
            return true;
        }
    }
