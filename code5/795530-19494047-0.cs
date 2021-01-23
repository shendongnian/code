    public class recipients: List<gsm>
    {
        private List<gsm> gsms{ get; set; }
        public recipients()
        {
            gsms = new List<gsm>();
        }
        public IEnumerator<gsm> GetEnumerator()
        {
            return gsms.GetEnumerator();
        }
    }
    public class gsm
    {
        [XmlText]
        public string number { get; set; }
        [XmlAttribute]
        public string messageId { get; set; }
    }
