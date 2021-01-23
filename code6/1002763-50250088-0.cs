     public MainPage()
            {
                InitializeComponent();
    
                conn = DependencyService.Get<ISQLite>().GetConnection();
    
    
                try
                {
                    var existTable = conn.Query<Student>("SELECT name FROM sqlite_master WHERE type='table' AND name='Student'; ");
    //Student is table name ,replace student by your table name
                    if ((existTable.Count > 0))
                    {
                       //Write code if table exists 
                    }
                }
                catch (Exception Ex)
                {
                   
                }
    
    
    
            }
