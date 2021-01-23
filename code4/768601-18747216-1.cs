        [XmlRoot(ElementName = "subject_datas")]
        public class SubjectDatas
        {
            [XmlElement(ElementName = "subject_data")]
            public List<SubjectData> SubjectDatas2 { get; set; }
            public SubjectDatas(IEnumerable<SubjectData> source)
            {
                SubjectDatas2= new List<SubjectData>();
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
