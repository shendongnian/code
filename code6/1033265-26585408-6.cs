        [XmlRootAttribute( "Submission", Namespace = "", IsNullable = false)]
        public class Submission : CanvasModel { 
            private List<Section> _sections = new List<Section>();
        
        [XmlIgnore]
        public virtual ICollection<Section> Sections
        {
            get { return _sections; }
            set { _sections = value.ToList(); }
        }
    
        [XmlArray(ElementName="Sections")]
        [XmlArrayItem("Section", IsNullable = false)]
        public Section[] SectionsArray
        {
            get { return _sections.ToArray(); }
            set { _sections = value.ToList(); }
        }
        }
