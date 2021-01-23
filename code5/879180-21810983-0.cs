        public static void ShowStar(int p)
        {
            for (int i = 1; i < p * 2; i++)
                Console.WriteLine(new string('*', (i < p) ? i : p * 2 - i));
        }
