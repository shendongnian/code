       int[] b = { 3, 2, 5, 4, 1 };
        int c;
        for (int p = 0; p <= b.Length - 2; p++)
        {
            for (int i = 0; i <= b.Length - 2; i++)
            {
                if (b[i] > b[i + 1])
                {
                    c = b[i + 1];
                    b[i + 1] = b[i];
                    b[i] = c;
                    foreach (int aa in b)
                      Console.Write(aa + " ");
                    Console.WriteLine();
                }
            }
        }
        Console.ReadLine();
