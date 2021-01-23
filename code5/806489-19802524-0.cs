    IODataRequestMessageAsync request = new ODataHttpRequestMessage(this.Url);
    using (ODataMessageReader reader = new ODataMessageReader(request))
    {
       ...
    }
