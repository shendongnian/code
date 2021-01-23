            int[,] a = new int[4,4];
            int quadrent = 1;
            for (int x = 0; x < 4; x++)
            {
                for (int y = 0; y < 4; y++)
                {
                    if (x < 2)
                    {
                        if (y < 2)
                        {
                            quadrent = 1;
                        }
                        else
                        {
                            quadrent = 2;
                        }
                    }
                    else
                    {
                        if (y < 2)
                        {
                            quadrent = 3;
                        }
                        else
                        {
                            quadrent = 4;
                        }
                    }
                    a[x, y] = quadrent;
                }
            }
            int i, j;
            /* output each array element's value */
            for (i = 0; i < 4; i++)
            {
                Console.WriteLine(String.Format("{0}, {1}, {2}, {3}", a[i, 0], a[i, 1], a[i, 2], a[i, 3]));
            }
            //split the line;
            Console.WriteLine();
            Console.WriteLine();
            Array.Copy(a, 0, a, 11, 4);
            for (i = 0; i < 4; i++)
            {
                Console.WriteLine(String.Format("{0}, {1}, {2}, {3}", a[i, 0], a[i, 1], a[i, 2], a[i, 3]));
            }
            Console.ReadKey();
