    public static class Extensions
    {
        public static void Shuffle<T>(this IList<T> list)
        {
            var rnd = new Random();
            for (int i = list.Count - 1; i >= 0; i--)
            {
                var r = rnd.Next(i + 1);
                T value = list[r];
                list[r] = list[i];
                list[i] = value;
            }
        }
    }
