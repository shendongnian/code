    static IEnumerable<List<Item>> GetXMany(int pageSize)
    {
        for (int i = 0; i < items.Count(); i+=pageSize)
        {
            yield return items.Skip(i).Take(pageSize).ToList();
        }
    }
