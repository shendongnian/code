    public override Task OnConnected()
    {
     var value1 = Convert.ToString(Context.QueryString["key1"]);
     var value2 = Convert.ToString(Context.QueryString["key2"]);
     return base.OnConnected();
    }
