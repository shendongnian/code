    private string _data;
    public int id { get; set; }
    public string data
    {
        get { return _data; }
        set
        {
            _data = value;
            loadData();
        }
    }
    public PlayerData PlayerData { get; set; }
    public void loadData()
    {
        var dataRows = data.Split(',');
        PlayerData = new PlayerData(Int32.Parse(dataRows[0]), dataRows[1], dataRows[2]);
    }
