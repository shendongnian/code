        [XmlRoot(ElementName = "subject_datas")]
        public class SubjectDatas
        {
            [XmlElement(ElementName = "subject_data")]
            public List<int> SubjectDatas2 { get; set; }
            public SubjectDatas(IEnumerable<int> source)
            {
                SubjectDatas2= new List<int>();
                this.SubjectDatas2.AddRange(source);
                Type = "array";
            }
            private SubjectDatas()
            {
                Type = "array";
            } 
            [XmlAttribute(AttributeName = "type")]
            public string Type { get; set; }
        }
