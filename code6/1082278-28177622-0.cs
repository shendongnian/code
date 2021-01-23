        static void Main(string[] args)
        {
            int limit = 17;
            int listSize = 5;
            List<int> a = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };
            a.Shuffle();
            List<int> genList = new List<int>();
            int stoppedCount = 0;
            for (int i = 0; i < a.Count(); i++)
            {
                if (i < listSize)
                {
                    genList.Add(a[i]);
                    stoppedCount = i;
                }
                else
                {
                    break;
                }
            }
            while (genList.Sum() > limit)
            {
                genList.Remove(genList.Max());
                stoppedCount++;
                genList.Add(a[stoppedCount]);
            }
        }
    }
    static class ThisClass
    {
        public static void Shuffle<T>(this IList<T> list)
        {
            Random rng = new Random();
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
