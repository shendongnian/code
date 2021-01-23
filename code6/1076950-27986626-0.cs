    public class inoutboundpd 
    {
        public string srcip { get; set; }
        public string srcport { get; set; }
        public string dstip { get; set; }
        public string dstport { get; set; }
        public string protocol { get; set; }
        public ICommand dpibutton { get; set; }
        public ICommand delbutton { get; set; }
    }
