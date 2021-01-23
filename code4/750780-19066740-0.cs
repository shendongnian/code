         private static void pyramid()
        {
             int k = 10;
            int j=0;
            while(true)
            {
                int i = 0;
                while(true)
                {
                    if (i >= (k - j) && i <= (k + j))
                    {
                        Console.Write("*");
                        Console.Write("\t");
                    }
                    else
                    {
                        Console.Write("\t");
                    }
                    if (i > (j + k))
                    {
                        break;
                    }
                    i++;
                }
                Console.Write("\n");
                if (j == (k - 1))
                {
                    break;
                }
                    j++;
            }
        }
