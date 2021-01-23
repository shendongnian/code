    private static XBMC LoadXbmcShows(string XMlFile)
    {
      XBMC XBMCSShowsList;
      TextReader Reader = new StreamReader(XMlFile);
      XmlSerializer serializer = new XmlSerializer(typeof(XBMC));
      XBMCSShowsList = (XBMC)serializer.Deserialize(Reader);
      Reader.Close();
      return XBMCSShowsList;
    }
    readonly ObservableCollection<XBMCShow> myCollection = 
      new ObservableCollection<XBMCShow>()
        
    public ObservableCollection<XBMCShow> MyCollection 
    { get { return myCollection; } }
    public MainWindow()
    {
      InitializeComponent();
      
      XBMC XBMCSList = LoadXbmcShows(_XMLFile);
      myCollection = new new ObservableCollection<XBMCShow>(XBMCSList.Show);
      Showlistbox.ItemsSource = myCollection;
    }
