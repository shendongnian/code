    public void Page_Load(object sender, EventArgs e)
    {
        RegisterAsyncTask(new PageAsyncTask(ProcessDataAsync));
    }
     
    public async Task ProcessDataAsync()
    {
        foreach (string v in options)
        {
            IList<MySampleNode> nodes = await _pi.GetDataAsync(v);
            _dbService.SaveToDb(nodes);
        }
    }
    
    public async Task<IList<MySampleNode>> GetDataAsync(string v)
    {
        IList<MySampleNode> nodes = null;
        using (var client = new WsClient())
        {
            IEnumerable<IWsObject> wsNodes = await client.getNodesAsync(new getClassLevel { code = v });
            nodes = ProcessData(wsNodes);
        }
        return nodes;
    }
