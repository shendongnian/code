    [XmlRoot(ElementName = "Record")]
    public class Results
    {
    	[XmlArray(ElementName = "Ids"), XmlArrayItem(ElementName = "Id")]
    	public List<Guid> itemGuid { get; set; }
    
    	[XmlArray(ElementName = "StoragePaths"), XmlArrayItem(ElementName = "StoragePath")]
    	public List<string> storagePath { get; set; }
    
    	[XmlElement(ElementName = "UploadedUserId")]
    	public int userId { get; set; }
    }
