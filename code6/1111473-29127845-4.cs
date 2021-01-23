    [XmlRootAttribute("root")]
    public class TestConfig
    {
        public TestConfig()
        {
            TestList = new List<string>();
        }
    
        private List<string> testList;
    
        [XmlIgnore]
        public List<string> TestList
        {
            get
            {
                if (this.testList == null)
                {
                    var newCollection = new List<string>();
    
                    if (this.cdataList != null)
                    {
                        foreach (var x in this.cdataList)
                        {
                            newCollection.Add(x.Value);
                        }
                    }
    
                    this.testList = newCollection;
                    this.cdataList = null;
                }
    
                return this.testList;
            }
            set
            {
                this.testList = value;
                this.cdataList = null;
            }
        }
    
        private List<XmlCDataSection> cdataList;
    
        [XmlArray("tlist")]
        [XmlArrayItem("item")]
        public List<XmlCDataSection> CdataList
        {
            get
            {
                if (this.cdataList == null)
                {
                    var newCollection = new List<XmlCDataSection>();
    
                    if (this.testList != null)
                    {
                        foreach (var x in this.testList)
                        {
                            newCollection.Add(new XmlDocument().CreateCDataSection(x));
                        }
                    }
    
                    this.cdataList = newCollection;
                    this.testList = null;
                }
    
                return this.cdataList;
            }
            set
            {
                this.cdataList = value;
                this.testList = null;
            }
        }
    
        public void Save(string path)
        {
            var serializer = new XmlSerializer(GetType());
            using (var stream = new StreamWriter(path))
            {
                serializer.Serialize(stream, this);
            }
        }
    
        public static TestConfig Load(string path)
        {
            var serializer = new XmlSerializer(typeof(TestConfig));
            using (var stream = new StreamReader(path))
            {
                return (TestConfig)serializer.Deserialize(stream);
            }
        }
    }
