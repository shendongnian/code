    public TotalTrueCount {get; set;}
    public bool Requirement(int input)
    {
        if (input % 8 == 0 && input % 11 == 0)
        {
            Console.WriteLine("True");
            TotalTrueCount++;
            
            return true;
        }
        return false;
    }
