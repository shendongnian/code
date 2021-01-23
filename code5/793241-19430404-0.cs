    public Task<IPAddress> GetInternetIP()
    {
        return Task.Factory.StartNew(() =>
        {
            IPAddress ip;
    
            // do some work to get the IPAddress
    
            return ip;
        });
    }
    
    private void Form_Load(object sender, EventArgs e)
    {
        GetInternetIP().ContinueWith(ip =>
        {
            Label1.Text = ip.ToString();
        }, TaskScheduler.FromCurrentSynchronizationContext());
    }
