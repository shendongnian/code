        public static T PopRandom<T>(this IList<T> list, Func<T, bool> predicate)
        {
            var predicatedList = list.Where(x => predicate(x));
            int count = predicatedList.Count();
            if (count == 0)
            {
                throw new Exception();
            }
            T item = predicatedList.ElementAt(Rand.Next(count));
            while (item != null && !predicate(item))
            {
                item = predicatedList.ElementAt(Rand.Next(list.Count));
            }
            list.Remove(item);
            return item;
        }
        public static void Shuffle<T>(this IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = Rand.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
