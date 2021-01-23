        {
            int a = 1, b, s = 1, n = 5;
            for (; a <= n; s = s * 10 + 1)
            {
                for (b = n - a; b >= 1; b--)
                {
                    Console.Write(" ");
                }
                Console.Write(s * s);
                Console.WriteLine();
                a++;
            }
        }
    }
