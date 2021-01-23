    public class Tshockversion
    {
        public int Major { get; set; }
        public int Minor { get; set; }
        public int Build { get; set; }
        public int Revision { get; set; }
        public int MajorRevision { get; set; }
        public int MinorRevision { get; set; }
    }
    
    public class JsonResponse
    {
        public string status { get; set; }
        public string name { get; set; }
        public string serverversion { get; set; }
        public Tshockversion tshockversion { get; set; }
        public int port { get; set; }
        public int playercount { get; set; }
        public int maxplayers { get; set; }
        public string world { get; set; }
        public string uptime { get; set; }
        public bool serverpassword { get; set; }
    }
