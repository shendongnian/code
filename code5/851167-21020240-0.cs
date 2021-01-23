    public struct EventData 
    {
        public int id;
        public string name;
        public int position;
        public string auxiliary;
    }
    ...
    void OnEventReceived(EventData ev) {
        var infoRecord = ev.Select(x => new { x.name, x.id }).ToArray();
        ...
    }
