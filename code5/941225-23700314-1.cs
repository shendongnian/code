    public delegate void DoAsync();
    private void button1_Click(object sender, EventArgs e)
    {
        DoAsync async = new DoAsync(GetThermoDetails);
        async.BeginInvoke(null, null);
    }
    public void GetThermoDetails()
    {
        while (true)
        {
           //your code comes here
        }
    }
