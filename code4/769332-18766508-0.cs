    public class cIntList
    {
        public string Name{ get; set; }
        [XmlElement("")]
        public List<IntData> IntList{ get; set; }
        public cIntList()
        {
            Name = "Name";
            IntList = new List<IntData>();
            IntList.Add(new IntData() { Value = 1 });
            IntList.Add(new IntData() { Value = 2 });
        }
    }
