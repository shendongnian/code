    public static class Extensions
    {
        public static void Shuffle<T>(this IList<T> list, Random rand)
        {
           for (int i = list.Count - 1; i > 0; i--)
           {
               int n = rand.Next(i + 1);
               int tmp = list[i];
               list[i] = list[n];
               list[n] = tmp;
           }
        }
    }
