    [XmlRoot("SHEET")]
    public class Sheet
    {
    	[XmlElementAttribute("books")]
    	public sheetBooks[] books;
    
    	public Sheet()
    	{}
    }
    
    public class sheetBooks
    {
    	[XmlAttribute("title")]
    	public string title;
    
    	[XmlElementAttribute("book")]	
    	public sheetBook book;
    
    	public sheetBooks()
    	{}
    }
    
    public class sheetBook
    {
    	[XmlAttribute("label")]
    	public char label;
    
    	[XmlAttribute("page")]
    	public char page;
    
    	[XmlAttribute("intro")]
    	public char intro;
    
    	public sheetBook()
    	{}
    }
