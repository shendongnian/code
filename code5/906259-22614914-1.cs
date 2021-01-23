    public static List<T> GetValidRecords<T>(this IEnumerable<T> source) where T: class, IGetListOfTables
    {
        if (null == source)
        {
            throw new ArgumentNullException("source");
        }
        return source.Where(x => x.Valid == 1).ToList();
    }
