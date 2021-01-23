    [SerializableAttribute()]
    [XmlRootAttribute("Sections", Namespace = "", IsNullable = false)]
    public partial class Sections {
        private Section[] sectionField;
        [XmlElementAttribute("Section")]
        public Section[] Section
        {
          get { return this.sectionField; }
          set { this.sectionField = value; }
        }
      }
