    private static XBMC LoadXbmcShows(string XMlFile)
    {
      XBMC XBMCSShowsList;
      TextReader Reader = new StreamReader(XMlFile);
      XmlSerializer serializer = new XmlSerializer(typeof(XBMC));
      XBMCSShowsList = (XBMC)serializer.Deserialize(Reader);
      Reader.Close();
      return XBMCSShowsList;
    }
    readonly ObservableCollection<XBMC> myCollection = new ObservableCollection<XBMC>()
        
    public ObservableCollection<XBMC> MyCollection {get { return myCollection; }}
    public MainWindow()
    {
      InitializeComponent();
      Showlistbox.ItemsSource = XBMCSList.Show;
      
      XBMC XBMCSList = LoadXbmcShows(_XMLFile);
      MyCollection.Add(XBMCSList);
    }
