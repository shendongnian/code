    public void Page_Load(object sender, EventArgs e)
    {
        RegisterAsyncTask(new PageAsyncTask(ProcessDataAsync));
    }
     
    public async Task ProcessDataAsync()
    {
        var tasks = options.Select(v => _pi.GetDataAsync(v));
        await Task.WhenAll(tasks);
        var nodes = options.Select(t => t.Result);
        _dbService.SaveToDb(nodes);
    }
    
    public async Task<IList<MySampleNode>> GetDataAsync(string v)
    {
        IList<MySampleNode> nodes = null;
        using (var client = new WsClient())
        {
            IEnumerable<IWsObject> wsNodes = 
                await client.getNodesAsync(new getClassLevel { code = v });
            nodes = ProcessData(wsNodes);
        }
        return nodes;
    }
