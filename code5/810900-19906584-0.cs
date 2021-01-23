    public class Database
    {
        public string Name { get; set; }
        public string ConnectionString { get; set; }
    }
    public static class Databases
    {
        public ICollection<Database> DatabaseList { get; private set; }
        public void AddDatabase(Database db)
        {
            DatabaseList.Add(db);
        }
        public void RemoveDatabase(string dbName)
        {
            DatabaseList.Remove(DatabaseList.Single(db => db.Name == dbName));
        }
    }
