    {
            ctx.CreateIfNotExists();
            var tdr = from ii in
                          (
                              from p in ctx.Transactions
                              join c in ctx.Type on p.Type equals c.Id
                              where p.Date > DateTime.Today.AddDays(-1 * ra) && c.Type1.Equals(ty)
                              select new { Id = p.Id, amont = p.Amont, type = c.Name, des = p.Des, dated = p.Date }
                              )
                      group ii by ii.Id into iii select new KeyedList<string, COLLECTIONITEM>(iii);
            list32.ItemsSource = new List<KeyedList<string, COLLECTIONITEM>>(tdr);
        } 
    public class KeyedList<TKey, TItem> : List<TItem>
        {
            public TKey Key { protected set; get; }
    
            public KeyedList(TKey key, IEnumerable<TItem> items)
                : base(items)
            {
                Key = key;
            }
    
            public KeyedList(IGrouping<TKey, TItem> grouping)
                : base(grouping)
            {
                Key = grouping.Key;
            }
        }
