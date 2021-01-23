    public void IsTyping (string html) 
    {
        // do stuff with the html
        SayWhoIsTyping(html); //call the function to send the html to the other clients
    }
    public void SayWhoIsTyping (string html)
    {
        IHubContext context = GlobalHost.ConnectionManager.GetHubContext<ChatHub>();
        context.Clients.All.sayWhoIsTyping (html);
    }
