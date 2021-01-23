    public sealed class DataManager : IDataManager
    {
        static DataManager()
        {
            using (var context = new MyDataContext())
            {
                _queryableTable1 = context.StaticTable1.AsNoTracking()
                                          .ToList()
                                          .AsQueryable();
            }
        }
    
        private static readonly IQueryable<StaticTable1> _queryableTable1;
        public IQueryable<StaticTable1> QueryableTable1 
        {
            get { return _queryableTable1; } 
        }
    }
