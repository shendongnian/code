    static void Combo(int a, int b, int c)
    {
        if (a < 10)
        {
            if (b < 10)
            {
                if (c < 10)
                {
                    Console.WriteLine("( {0}, {1}, {2})", a, b, c);
                    Combo(a, b, ++c);
                }
                else
                {
                    c = 0;
                    Combo(a, ++b, c);
                }
            }
            else
            {
                c = 0; b = 0;
                Combo(++a, b, c);
            }
        }
    }
