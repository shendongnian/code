    public static void PrintKeyValuePairs<T, U>(Dictionary<T, U> dict)
            where T : IComparable
            where U : IComparable
        {
            foreach (KeyValuePair<T, U> item in dict)
            {
                Console.WriteLine("{0}: {1}", item.Key, item.Value);
            }
        }
