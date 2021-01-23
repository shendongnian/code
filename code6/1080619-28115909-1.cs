    public class TablesProvider
    {
        private readonly List<object> _tables;
    
        public TablesProvider()
        {
            _tables = new List<object>();
        }
    
        public IList<TItem> GetTable<TItem>()
        {
            // not very efficient search
            var lst = (List<TItem>)_tables.SingleOrDefault(x => x is List<TItem>);
    		if (lst == null)
    		{
    			lst = new List<TItem>();
    			_tables.Add(lst);
    		}
    		return lst;
        }
    }
 
