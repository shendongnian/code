    private IEnumerable<T> QueryCollection<T>() where T : BaseObj
    {
         IEnumerable<T> items = query<T>();
         ICollection<T> itemsCollection = items as ICollection<T> ?? items.ToList();
         if (itemsCollection.Count > 0)
         {
             var firstItem = itemsCollection.First();
             if (firstItem is ITeamFilterable)
                 return FilterByTeams(itemsCollection);
         }
         return itemsCollection;
    }
