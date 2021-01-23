    [XmlType("formats")]
    public class Formats
    {
    	[XmlArray("items")]
    	public List<Item> Items { get; set; }
    	
    	[XmlArray("styles")]
    	public List<Style> Styles { get; set; }
    }
    
    [XmlType("item")]
    public class Item
    {
    	[XmlAttribute("itemkind")]
    	public string ItemKind { get; set; }
    
    	[XmlElement("phrase")]
    	public string Phrase { get; set; }
    	
    	[XmlArray("actions")]
    	public List<Action> Actions { get; set; }
    }
    
    [XmlType("action")]
    public class Action
    {
    	[XmlElement("actionkind")]
    	public string ActionKind { get; set; }
    	
    	[XmlElement("parameter")]
    	public string Parameter { get; set; }
    }
    
    [XmlType("style")]
    public class Style
    {
    	[XmlAttribute("stylename")]
    	public string StyleName { get; set; }
    	
    	[XmlElement("fontname")]
    	public string FontName { get; set; }
    	
    	[XmlElement("fontsize")]
    	public int FontSize { get; set; }
    	
    	[XmlElement("bold")]
    	public int Bold { get; set; }
    }
