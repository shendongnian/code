    protected void btn_Click(object sender, EventArgs e)
    {
        ServiceReference1.countrySoapClient Client = new ServiceReference1.countrySoapClient("countrySoap12");
    
        String Countries = Client.GetCountries();
    }
