    public static class MyExtensions
    {
        public static void SaveToFile<T>(this List<T> list, string filename)
        {
            System.IO.File.WriteAllLines(filename, list.Select(v => v.ToString()).ToArray());
        }
        public static void FillFromFile<T>(this List<T> list, string filename, Func<string, T> parser)
        {
            foreach (var line in System.IO.File.ReadAllLines(filename))
            {
                T item = parser(line);
                list.Add(item);
            }
        }
    }
