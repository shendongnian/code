        public class Program
    {
        private const string ConnectionString = "Data Source=:memory:;Version=3;New=True;";
        public static void Main()
        {
            var dataProvider = new SQLiteDataProvider();
            var connection = dataProvider.CreateConnection(ConnectionString);
            connection.Open();
            var dataConnection = new DataConnection(dataProvider, connection);
            dataConnection.MappingSchema.SetDataType(typeof(TimeSpan), DataType.Int64);
            dataConnection.CreateTable<Category>();
            dataConnection.GetTable<Category>()
                .DataContextInfo
                .DataContext
                .Insert(new Category
                {
                    Id = 2,
                    Time = new TimeSpan(10, 0, 0)
                });
            
            foreach (var category in dataConnection.GetTable<Category>())
            {
                Console.WriteLine($@"Id: {category.Id}, Time: {category.Time}");
            }
        }
        private class Category
        {
            public int Id { get; set; }
            public TimeSpan Time { get; set; }
        }
    }
