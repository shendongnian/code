    [Serializable]
    [XmlRoot("Material")]
    public class Material
    {
        public Material() { }
    
        [XmlElement("MatNr")]
        public string MatNr { get; set; }
        [XmlElement("MatDescrEN")]
        public string MatDescrEN { get; set; }
        [XmlElement("MatDescrNL")]
        public string MatDescrNL { get; set; }
        [XmlElement("MatDescrFR")]
        public string MatDescrFR { get; set; }
        [XmlElement("OldMatNr")]
        public string OldMatNr { get; set; }
        [XmlElement("UoM")]
        public string UoM { get; set; }
        [XmlElement("MatGroupCode")]
        public string MatGroupCode { get; set; }
        [XmlElement("Extract")]
        public String ExtractString { get; set; }
    	[XmlIgnore]
    	public decimal Extract
    	{
    		get { return String.IsNullOrWhiteSpace(this.ExtractString) ? 0M : decimal.Parse(this.ExtractString); }
    		set { this.ExtractString = this.Extract.ToString(CultureInfo.InvariantCulture); }
    	}
        [XmlArray("AdditionalData"), XmlArrayItem(ElementName = "AddDataRecord", Type = typeof(AddDataRecord))]
        public AddDataRecord[] AdditionalData { get; set; }
        [XmlArray("PlantData"), XmlArrayItem(ElementName = "PlantDataRecord", Type = typeof(PlantDataRecord))]
        public PlantDataRecord[] PlantData { get; set; }
    }
    
    [Serializable]
    [XmlRoot("AddDataRecord")]
    public class AddDataRecord
    {
        [XmlElement("UoMDenom")]
        public int UoMDenom { get; set; }
        [XmlElement("UoMAlt")]
        public string UoMAlt { get; set; }
        [XmlElement("UoMNum")]
        public int UoMNum { get; set; }
        [XmlElement("UoMBase")]
        public string UoMBase { get; set; }
    }
    
    [Serializable]
    [XmlRoot("PlantDataRecord")]
    public class PlantDataRecord
    {
        [XmlElement("Plant")]
        public string Plant { get; set; }
        [XmlElement("Recipient")]
        public string Recipient { get; set; }
        [XmlElement("Status")]
        public string Status { get; set; }
    }
    
    [XmlRoot("Materials", Namespace = "www.foo.be/foo/")]
    [Serializable]
    public class MaterialCollection
    {
       [XmlElement("Material", Namespace="")]
       public List<Material> Materials { get; set; }
    }
