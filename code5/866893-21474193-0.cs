        InitializeComponent();
        _connection = new HubConnection(websiteUrl);
        _myHub = _connection.CreateHubProxy("GameManager");
        InitializeConnection();
    }
    public async Task InitializeConnection()
    {
        try
        {
            var obj = new
            {
                header = 0,
                data = App.login,
            };
            var result = JsonConvert.SerializeObject(obj, Formatting.Indented);
           _myHub.On<string>("recieved", data =>
            {
                if (OnRecieved != null)
                {
                    OnRecieved(this, new ChatEventArgs { MessageSent = data });
                    System.Diagnostics.Debug.WriteLine("DATA : " + data);
                }
            });
            await _connection.Start();
            await _myHub.Invoke("SendConnection", result);
            IsConnected = true;
           
            if (OnConnected != null)
            {
                OnConnected(this, new EventArgs());
            }
        }
        catch(Exception ex)
        {
        }
    } 
