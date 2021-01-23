    private bool IsZero(int value)
    {
        return value == 0;
    }
    public void Function_Deus()
    {
        Func<int, bool> variable = IsZero;
        if (variable(0))  // IS THIS POSSIBLE?
        {
            Console.WriteLine("Success");
        }
    }
