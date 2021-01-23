    using System.Linq;
    // ...   
    private static List<T> GetAllTypesInContainer<T>(this Container bw)
    {
        var list = bw.GetChildren().OfType<T>().ToList();
        return list;
    }
