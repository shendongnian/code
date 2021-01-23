    public class IpCamera
    {
        public int        Id         { get; set; }
        public string     Token      { get; set; }
        public IPAddress  IPAddress  { get; set; }
        public string     RtspUri    { get; set; }
        public bool       IsOnline   { get; set; }
    }
