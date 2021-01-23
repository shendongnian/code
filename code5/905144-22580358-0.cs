    static class MyEnumerableExtensions
    {
        //For a source containing N delimiters, returns exactly N+1 lists
        public static IEnumerable<List<T>> SplitOn<T>(
            this IEnumerable<T> source,
            T delimiter)
        {
            var list = new List<T>();
            foreach (var item in source)
            {
                if (delimiter.Equals(item))
                {
                    yield return list;
                    list = new List<T>();
                }
                else
                {
                    list.Add(item);
                }
            }
            yield return list;
        }
    }
    public InsertLine()
    {       
        byte[] bytes = File.ReadAllBytes(...);
        List<List<byte>> lines = bytes.SplitOn((byte)'\n').ToList();
        string lineToInsert = "Insert this";
        byte[] bytesToInsert = Encoding.Default.GetBytes(lineToInsert);
        lines.Insert(2, new List<byte>(bytesToInsert));
        File.WriteAllBytes(..., lines.SelectMany(x => x).ToArray());
    }
