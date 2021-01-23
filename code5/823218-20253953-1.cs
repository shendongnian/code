    public interface IWeirdList
    {
        int Count { get; }
        object ItemByIndex(int index);
    }
    public static List<T> ToList<T>(this IWeirdList source)
    {
        List<T> results = new List<T>(source.Count);
        for (int i = 1; i <= source.Count; i++)
        {
            results.Add((T)source.ItemByIndex(i));
        }
        return results;
    }
    var list = myIManDocuments.ToList<IManDocument>();
