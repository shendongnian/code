    public class Test
    {
       public int Id {get;set;}
    }
    private ICollection<T> AddRelationalData<T>(List<int> relationalDataIds)
        where T : Test, new()
    {
        var relationalDataCollection = new Collection<T>()
        if (relationalDataIds != null && relationalDataIds.Count > 0)
        {
            foreach (var entry in relationalDataIds.Select(id => new T {Id = id}))
            {
                relationalDataCollection.Add(entry);
            }
        }
        return relationalDataCollection;
    }
