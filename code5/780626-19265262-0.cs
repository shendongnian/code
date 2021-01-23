    public class DataContextBase : DataContext
    {
        public DataContextBase(string connectionString) : base(connectionString)
        { }
        //Tables for library's internal workings.
        public Table<SyncTimeStamp> SyncTimeStamps;
    }
