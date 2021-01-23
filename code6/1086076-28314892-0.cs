    public class DocumentType
    	{
    		[XmlElement("Document")]
    		public string Name {get; set;}
    	}
    
    
    public class Test
    {
    	private List<DocumentType> _attachments = new List<DocumentType>();
    
    	[XmlArrayItem("Documents", IsNullable = false)]
    	public List<DocumentType> Attachments
    	{
    		get
    		{
    			return this._attachments;
    		}
    		set
    		{
    			this._attachments = value;
    		}
    	}
    }
