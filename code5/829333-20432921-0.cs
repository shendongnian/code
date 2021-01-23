    public class Record
    {
    	public List<Field> Fields { get; set; }
    	public Record()
    	{
    		Fields = new List<Field>();
    	}
    }
     
    public class Field
    {
    	public string Name { get; set; }
    	public string Value { get; set; }
    	public string Caption { get; set; }
    
    	public Field(){}
    }
    
    Field ReadField(XElement fieldElement)
    {
    	return new Field{
    		Name = (string)fieldElement.Element("Name"),
    		Value = (string)fieldElement.Element("Value"),
    		Caption = (string)fieldElement.Element("Caption")
    	};
    }
    void Main()
    {
    	
    	var lstRecords = new List<Record>();	
    	
    	XDocument doc = XDocument.Load(@"c:\fred\output.xml");
    
    var query = from record in doc.XPathSelectElements("/XXXXXXXXXXXXXXXXXX/Records/Record")
    select new Record
    	{
    		Fields = record.Elements("Field").Select (f => ReadField(f)).ToList(),
    	};
    
    query.Dump();
    	
    }
