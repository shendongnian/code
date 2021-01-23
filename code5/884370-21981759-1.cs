        string country = "Full Schedule";
        List<match_schedule> ScheduleList;
        // the local folder DB path
        string DB_PATH = Path.Combine(ApplicationData.Current.LocalFolder.Path, "sample.sqlite");
        //SQLite connection
        private SQLiteConnection dbConn;
        ProgressIndicator _progressIndicator = new ProgressIndicator();
        private List<string> _source = new List<string>
        {
            "Full Schedule","Afghanistan","Australia","Bangladesh","England","Hong Kong","India","Ireland","Nepal","Netherlands","New Zealand","Pakistan","South Africa","Sri Lanka","UAE","West Indies","Zimbabwe"
        };
        public Schedule()
        {
            InitializeComponent();
            selectTeam.ItemsSource = _source;
            Loaded += Schedule_Loaded;
        }
        void Schedule_Loaded(object sender, RoutedEventArgs e)
        {
            
        }
        private void selectTeam_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            country = (sender as ListPicker).SelectedItem.ToString();
            dbConn = new SQLiteConnection(DB_PATH);
            /// Create the table Task, if it doesn't exist.
            dbConn.CreateTable<match_schedule>();
            if (country == "Full Schedule")
            {
                ScheduleList = dbConn.Query<match_schedule>("select * from tableName").ToList<match_schedule>();
            }
            else
            {
               ScheduleList = dbConn.Query<match_schedule>("select * from tableName where team1_Name=? or team2_Name=?", country).ToList<match_schedule>();
            }
            scheduleListbox.ItemsSource = ScheduleList;         
        }
    }
    public class match_schedule
    {
        [PrimaryKey, AutoIncrement]
        public int match_id { get; set; }
        public string team1_Name { get; set; }
        public string team2_Name { get; set; }
        public string match_no { get; set; }
        public string group { get; set; }
        public string venue { get; set; }
        public string time { get; set; }
        public string day { get; set; }
    }
