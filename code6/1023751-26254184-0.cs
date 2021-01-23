            int[] num = new int[11];
            int j = 0;
            for (int i = 1; i < 10; i++)
            {
               
                if (i%4 != 0)
                {
                    num[i] = i - j;
                }
                else
                {
                    j= j + 1;
                }
               
            }
            foreach (var item in num)
            {
                Console.Write(item + " ");
            }
            Console.Read();
