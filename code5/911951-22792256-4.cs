    foreach (CardNumber val in Enum.GetValues(typeof(CardNumber)))
    {
        foreach (Suit val1 in Enum.GetValues(typeof(Suit)))
        {
            if ((int)val > 10)
            {
                Console.Write("{0} of {1}", val, val1);
            }
            else
            {
                Console.Write("{0} of {1}", (int)val, val1);
            }
        }
        Console.WriteLine();
    }
