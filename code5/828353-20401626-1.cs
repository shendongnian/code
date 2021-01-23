    class Program
    {
        static void Main(string[] args)
        {
            var existingElements  = new List<int> { 1, 2, 3, 4, 5, 6 };
            var elementsToAdd = new List<int> { 100, 101, 102 };
            existingElements = existingElements.Mix(elementsToAdd).ToList();
            Console.WriteLine(String.Join(", ", existingElements));
            Console.ReadKey();
        }
    }
    
    public static class ExtensionMethods
    {
        public static IEnumerable<T> Mix<T>(this IEnumerable<T> source, IEnumerable<T> mix)
        {
            var list1 = source.ToArray();
            var list2 = mix.ToArray();
            var total = list1.Count() + list2.Count();
            var skip = (list1.Count() / list2.Count()) + 1;
            var count1 = 0;
            var count2 = 0;
            var finalList = new List<T>();
    
            for (var i = 0; i < total; i++)
            {
                var count = i + 1;
                if (count % skip == 0)
                {
                    finalList.Add(list2[count2]);
                    count2++;
                }
                else
                {
                    finalList.Add(list1[count1]);
                    count1++;
                }
            }
    
            return finalList;
        }
    }
