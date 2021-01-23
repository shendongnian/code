    public const string NewssXml = "Newss.xml";
    
    public News()
    {
    	InitializeComponent();
    	LoadData();
    }
    
    private void LoadData()
    {
    	bool isSuccess;
    	//try to load data from iso store
    	var doc = ReadXml(out isSuccess);
    	if(isSuccess) PopulateList(doc);
    	//if failed (data doesn't exists in iso store), download data from web service
    	else 
    	{
    		KejriwalService.aapSoapClient client = new KejriwalService.aapSoapClient();
    		client.getarvindNewsCompleted += new EventHandler<KejriwalService.getarvindNewsCompletedEventArgs>(client_getarvindNewsCompleted);
    		client.getarvindNewsAsync();
    
    		progressName.Visibility = System.Windows.Visibility.Visible;
    	}
    }
    
    //upon download completed, display data then save the xml to iso store
    void client_getarvindNewsCompleted(object sender, KejriwalService.getarvindNewsCompletedEventArgs e)
    {
    	var doc = XDocument.Parse(e.Result);
    	PopulateList(doc);
    	SaveXml(doc);
    }
    
    private void PopulateList(XDocument doc)
    {
    	List<Newss> listData = new List<Newss>();
    
    	progressName.Visibility = System.Windows.Visibility.Collapsed;
    
    	foreach (var location in doc.Descendants("UserDetails"))
    	{
    		Newss data = new Newss();
    		data.News_Title = location.Element("News_Title").Value;
    		data.News_Description = location.Element("News_Description").Value;
    		data.Date_Start = location.Element("Date_Start").Value;
    		data.image_path = location.Element("image_path").Value;
    		data.ImageBind = new BitmapImage(new Uri( @"http://political-leader.vzons.com/ArvindKejriwal/images/uploaded/"+data.image_path, UriKind.Absolute));
    		listData.Add(data);
    	}
    	listBox1.ItemsSource = listData;
    }
    
    private XDocument ReadXml(out bool isSuccess) 
    { 
    	isSuccess = false;
    	var doc = new XDocument(); 
    	using (IsolatedStorageFile store = IsolatedStorageFile.GetUserStoreForApplication()) 
    	{ 
    		try 
    		{ 
    			if (store.FileExists(NewssXml)) 
    			{ 
    				using (var sr = new StreamReader(new IsolatedStorageFileStream(NewssXml, FileMode.OpenOrCreate, store))) 
    				{ 
    					doc = XDocument.Load(sr); 
    				}
    				isSuccess = true;				
    			} 
    		} catch (Exception ex) { } 
    	} 
    	return doc; 
    }
     
    private bool WriteXml(XDocument document) 
    { 
    	using (IsolatedStorageFile store = IsolatedStorageFile.GetUserStoreForApplication()) 
    	{ 
    		try 
    		{ 
    			using (var sw = new StreamWriter(new IsolatedStorageFileStream(NewssXml, FileMode.Create, store))) 
    			{ 
    				sw.Write(document.ToString()); 
    			} 
    		} catch (Exception ex) { return false; } 
    	} 
    	return true; 
    }
