    foreach (Suit val1 in Enum.GetValues(typeof(Suit)))
    {
        foreach (CardNumber val in Enum.GetValues(typeof(CardNumber)))
        {
            if ((int)val > 10)
            {
                Console.WriteLine("{0} of {1}", val, val1);
            }
            else
            {
                Console.WriteLine("{0} of {1}", (int)val, val1);
            }
        }
    }
