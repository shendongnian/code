    [NonEvent]
    public void EndPage(string url) {
        this.EndPage(url, null);
    }
    [Event(eventId: 901, Version = 1)]
    public void EndPage(string url, string queryString) 
    {
        WriteEvent(901, url, queryString);
    }
