     public MainPage()
            {
                InitializeComponent();
    
                conn = DependencyService.Get<ISQLite>().GetConnection();
    
                try
                {
                    //Student is table name ,replace student with your table name
                    var existTable = conn.Query<Student>("SELECT name FROM sqlite_master WHERE type='table' AND name='Student'; ");
                    if ((existTable.Count > 0))
                    {
                       //Write code if table exists 
                    }
                }
                catch (Exception Ex)
                {       
                }
            }
