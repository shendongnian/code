    private string _mapFilePath = null;
    public ctrlCurrentLocation()
    {            
        InitializeComponent();
    }
    private void ReloadMap()
    {
        if(_mapFilePath != null && File.Exists(_mapFilePath))
        {
            string NewLine = System.Environment.NewLine;
            string strHeader = string.Concat("<?xml version=\"1.0\"?>", NewLine, "<TrackMap>", NewLine);
            string strLast = strHeader + string.Concat("</TrackMap>", NewLine);
            strXMLPath = AppDomain.CurrentDomain.BaseDirectory + "JavaScript\\TrackMap.xml";
            FileStream fs1 = File.Open(strXMLPath, FileMode.Create);
            StreamWriter writer1 = new StreamWriter(fs1, Encoding.UTF8);
            writer1.Write(strLast);
            writer1.Close();
            fs1.Dispose();
            .......
            .
            .
        }
    }
    public string MapFilePath
    {
        get { return _mapFilePath; }
        set
        {
            _mapFilePath = value;
            ReloadMap();
        }
    }
