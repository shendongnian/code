    public partial class MainWindow : Window
    {
    	public MainWindow()
    	{
    		InitializeComponent();
     		DataContext = this;
    		Task.Factory.StartNew(() => DoTheMagic());
    	}
    
    	// Here the magic occurs
    	public async Task DoTheMagic()
    	{
    		while (true)
    		{
    			string url = "http://query.yahooapis.com/v1/public/yql?q=select%20*%20from%20yahoo.finance.quotes%20where%20symbol%20in%20(%22YHOO%22)&diagnostics=true&env=http://datatables.org/alltables.env";
    			string raw = await GetResponse(url);
    			var parsed = await ParseXml(raw);
    
    			// Pass results to UI
    			Dispatcher.BeginInvoke(new Action(() =>
    				{
    					var now = DateTime.Now;
    					foreach (var tuple in parsed)
    						textBox.Text += string.Format("{0} {1} = {2}{3}", now, tuple.Item1, tuple.Item2, Environment.NewLine);
    				}));
    			Thread.Sleep(3000);
    		}
    	}
    
    	// Get response from service
    	public async Task<string> GetResponse(string url)
    	{
    		var request = WebRequest.Create(url);
    		
    		var response = await request.GetResponseAsync();
    		var stream = response.GetResponseStream();
    
    		if (stream == null)
    			return null;
    
    		string content;
    		using (var reader = new StreamReader(stream, Encoding.GetEncoding("utf-8")))
    			content = reader.ReadToEnd();
    
    		return content;
    	}
    
    	// Parse response with your logic
    	public Task<List<Tuple<string, string>>> ParseXml(string xml)
    	{
    		return Task.Factory.StartNew(() =>
    			{
    				var nodes = new string[] {"Symbol", "Ask", "Bid"};
    				var result = new List<Tuple<string, string>>();
    
    				using (var reader = new XmlTextReader(new StringReader(xml)))
    				{
    					reader.MoveToContent();
    					while (reader.Read())
    					{
    						if (reader.NodeType.Equals(XmlNodeType.Element))
    						{
    							if (nodes.Contains(reader.LocalName))
    								result.Add(new Tuple<string, string>(reader.LocalName, reader.ReadElementContentAsString()));
    						}
    					}
    				}
    				return result;
    			});
    	}
    }
