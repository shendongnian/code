    [DataContract]
    public class DemoSearchList : ReturnValuesBase
    {
        public DemoSearchList()
        {
            this.StartDate = new List<string>();
            this.EndDate = new List<string>();
        }
    
        [DataMember]
        public List<string> StartDate { get; set; }
    
        [DataMember]
        public List<string> EndDate { get; set; }
    }
