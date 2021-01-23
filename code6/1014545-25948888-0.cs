    // namespaces
    using SQLite;
    using System.IO;
    using System.IO.IsolatedStorage;
    using System.Threading.Tasks;
    // define a class like table to create
    public class Question
    {
        [SQLite.PrimaryKey, SQLite.AutoIncrement]
        public int Id { get; set; }
        public int Status { get; set; }
    } 
    public partial class MainPage : PhoneApplicationPage
    {
        string dbPath = "";
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            // combine the local folder with the file name of the database
            dbPath = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "db.sqlite");                        
            
            CreateDBTable();            
        }
        // from the MSDN article for getting SQLite to work
        private async Task<bool> FileExists(string fileName)
        {
            var result = false;
            try
            {
                var store = await Windows.Storage.ApplicationData.Current.LocalFolder.GetFileAsync(fileName);
                result = true;
            }
            catch
            {
            }
            return result;
        }
        // if the file doesn't exist, create it with the db.CreateTable
        public void CreateDBTable()
        {
            if (!FileExists("db.sqlite").Result)
            {
                using (var db = new SQLiteConnection(dbPath))
                {
                    db.CreateTable<Question>();
                }
            } 
        }
    }
