    public static List<T> GetValidRecords<T>(this IEnumerable<T> source) where T: class, IGetListOfTables
    {
        try
        {
            return source.Where(x => x.Valid == 1).ToList();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
