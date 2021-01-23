    public class Zone
    {
        public string Name { get;set; }
        public ZoneEnum Id { get; set; }
        public string URL { get; set; }
        public ZoneToken CreateToken()
        {
            ...
        }
    }
