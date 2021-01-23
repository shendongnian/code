        static void Combo(int a, int b, int c)
        {
            Console.WriteLine("( {0}, {1}, {2})", a, b, c);
            if (a < 10)
            {
                Combo(++a, b, c);
                if (b < 10)
                {
                    Combo(a, ++b, c);
                    if (c < 10)
                    {
                        Combo(a, b, ++c);
                    }
                }
            }
        }
