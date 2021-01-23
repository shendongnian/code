    public bool IsFizz(int input)
    {
        if (input % 9 == 0)
        {
            Console.WriteLine("Fizz");
            countOfFizz++;
            return true;
        }
        return false;
    }
