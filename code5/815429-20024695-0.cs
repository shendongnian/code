    static int[] GenerateEratosthen()
        {
            bool[] e = new bool[200000];
            for (int i = 2; i < 200000; i++)
            {
                for (int j = 2; j * i < 200000; j++)
                {
                    e[j * i] = true;
                }
            }
            int[] p = new int[20000];
            int k = 0;
            for (int i = 1; i < 200000; i++)
            {
                if (!e[i])
                    p[k++] = i;
            }
            return p;
        }
