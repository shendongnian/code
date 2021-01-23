    static public ObservableCollection<GetDrive> RootDrive = new ObservableCollection<GetDrive>();
    
    public MainWindow()
    {
        InitializeComponent();
    
   
        foreach (DriveInfo di in DriveInfo.GetDrives())
        {
            try
            {
                directories.Clear();
                foreach (string s in Directory.GetDirectories(di.Name))
                {
                    directories.Add(new GetDirectory(s));
                }               
            }
    
            catch (IOException)  //drive is not ready, e.g. DVD drive
            {
    
            }
    
            finally
            {
                RootDrive.Add(new GetDrive(di.Name, directories));
                
            }
        }
    }
    
    }
