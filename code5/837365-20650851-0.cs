    public static class Extensions
    {
        public static IEnumerable<IEnumerable<int>> GroupsLessThan(this IEnumerable<int> source, int target)
        {
            var list = new List<int>();
            var runningCount = 0;
            foreach (var element in source)
            {
                if (runningCount + element < target)
                {
                    list.Add(element);
                    runningCount += element;
                }
                else
                {
                    yield return list;
                    runningCount = element;
                    list = new List<int>{element};
                }
            }
            if (list.Count > 0)
            {
                yield return list;
            }
        }
    }
