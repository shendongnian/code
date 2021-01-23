        public static void Main()
        {
            var arrays = GetArrays(5);
            var equal = true;
            for (int i = 0; i < arrays.Count(); i++)
            {
                for (int j = 0; j < arrays.Count(); j++)
                {
                    if (!arrays[i].SequenceEqual(arrays[j]))
                    {
                        equal = false;
                        break;
                    }
                }
                if (!equal)
                {
                    break;
                }
            }
            
            Console.WriteLine("The arrays {0} equal.", equal ? "are" : "are not");
        }
        public static IList<string[]> GetArrays(int count)
        {
            Func<int, string[]> generateArray = x => Enumerable.Range(0, 100).Select(y => y.ToString()).ToArray();
            return Enumerable.Range(0, count).Select(generateArray).ToList();
        }
