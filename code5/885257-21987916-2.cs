    public class DatabaseContext : DataContext
    {
        public DatabaseContext(string connectionString)
        : base(connectionString)
        {
        }
        public Table<ToDoList> ToDoLists
        {
            get
            {
                return this.GetTable<ToDoList>();
            }
        }
        public void CreateIfNotExists()
        {
            if (!this.DatabaseExists())
            {
                this.CreateDatabase();
            }
        }
        public const string ConnectionString = @"isostore:/MyDatabases.sdf";
    }
