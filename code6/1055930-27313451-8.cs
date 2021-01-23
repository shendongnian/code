    [Serializable]
    [XmlRoot]
    public class FormXml
    {
        public string ImportID  { get; set; }
        public string Environment { get; set; }
        public string DateExported { get; set; }  
        [XmlIgnore]
        public IEnumerable<FormType> FormType { get; set; }
        [XmlElement, Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public List<FormType> Foo { get { return FormType.ToList() } set { FormType = value; } }
    }
