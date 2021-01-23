    Random rnd = new Random();
    public int GenerateRandomNumber()
    {
        int from, to;
        while(true)
        {
            bool a = int.TryParse(Console.ReadLine(), out from);
            bool b = int.TryParse(Console.ReadLine(), out to);
            if(a && b) break;
            else Console.WriteLine("You have entered invalid numbers, please try again.");
        }
        return rnd.Next(from, to + 1);
    }
