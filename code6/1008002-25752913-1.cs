    //first at the class level, create a private variable for the client.
    private Service1Client _client;
    private Button _addButon;
    private TextView _txtDeptName;
    
    //Initialize the _client in the OnCreate() method.
    protected override void OnCreate(Bundle bundle)
    {
         base.OnCreate(bundle);
    
         var endpoint = new EndpointAddress("http://<ipAddress:port>/Service1.svc");
    
         var binding = new BasicHttpBinding{
            Name = "basicHttpBinding",
            MaxBufferSize = 2147483647,
            MaxReceivedMessageSize = 2147483647
        };
    
        TimeSpan timeout = new TimeSpan(0, 0, 30);
        binding.SendTimeout = timeout;
        binding.OpenTimeout = timeout;
        binding.ReceiveTimeout = timeout;
    
        _client = new Service1Client(binding, endpoint);
        _client.AddDeptCompleted += ClientAddDeptCompleted;
    
        _addButton = FindViewById<Button>(Android.Resources.Id.Add);
        _addbutton.Click += AddButton_Clicked;
        _txtDeptName = FindViewbyId<TextView>(Android.Resources.Id.Name);
    }
    
    //Then within the event handlers, do something like this
    public void AddButton_Clicked(object sender, EventArgs e)
    {
         _client.AddDeptAsync(_txtDeptName.Text);
    }
    
    //Handle the request completed event.
    private void ClientAddDeptCompleted(object sender, AddDeptCompletedEventArgs addDeptCompletedEventArgs)
    {
         //TODO: Something with the notification that the request has completed.
    }
