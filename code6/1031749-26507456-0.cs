    public static void PrintSerial(int _elements)
    {
        for (int i = 1; i <= _elements; i++)
        {
            int value = (int)Math.Round(((1.33 * Math.Pow(i, 3)) -
                           (7.5 * Math.Pow(i, 2)) +
                           (19.166 * Math.Pow(i, 1)) - 12));
            Console.Write("{0} ", value);
        }
    }
