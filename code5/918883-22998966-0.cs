    public class ActivityViewModel
    {
        public string Id { get; private set; }
    
        public string Category { get; private set; }
        public ActivityViewModel(string id, string category)
        {
            Id = id;
            Category = category;
        }
    }
    public class MainViewModel
    {
        private const string TABLE_NAME = "tblActivity";
        private const string COLUMN_NAME_ID = "ActivityID";
        private const string COLUMN_NAME_CATEGORY = "Activity_Category";
    
        private SQLiteConnection _con;
    
        public IEnumerable<ActivityViewModel> Activities { get; private set; }
        public MainViewModel()
        {
            _con = new SQLiteConnection(...); // create your connection
            readFromDb();
        }
        
        private void readFromDb()
        {
            var list = new List<ActivityViewModel>();
            _con.Open();
            var sqlText = string.Format(
                "SELECT [{0}], [{1}] FROM {2}",
                COLUMN_NAME_ID,
                COLUMN_NAME_CATEGORY,
                TABLE_NAME);
            var sqlCmd = new SQLiteCommand(sqlText, _con);
            using(var reader = sqlCmd.ExecuteReader())
            {
                while(reader.Read())
                {
                    var id = reader[COLUMN_NAME_ID] as string;
                    var category = reader[COLUMN_NAME_CATEGORY] as string;
                    var newPair = new ActivityViewModel(id, category);
                    list.Add(newPair);
                }
            }
            _con.Close();
            Activities = list;
        }
    }
