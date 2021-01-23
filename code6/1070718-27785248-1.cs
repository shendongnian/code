    [XmlRoot()]
    public class XmlExample
    {
    	private NodeA_Elem _nodea;
    	[XmlElemnt("NodeA")]
    	public NodeA_Elem NodeA
    	{
    		get
    		{
    			return _nodea;
    		}
    		set
    		{
    			_nodea=value;
    		}
    	}
    	public bool ShouldSerializeNodeA()
        {
            return !String.IsNullOrEmpty(_nodea.value);
        }
    	
    	private NodeB_Elem _nodeb;
    	[XmlElemnt("NodeB")]
    	public NodeB_Elem NodeB
    	{
    		get
    		{
    			return _nodeb;
    		}
    		set
    		{
    			_nodeb=value;
    		}
    	}
    	public bool ShouldSerializeNodeB()
        {
            return !String.IsNullOrEmpty(_nodeb.value);
        }
    	private NodeC_Elem _nodec;
    	[XmlElemnt("NodeC")]
    	public NodeC_Elem NodeC
    	{
    		get
    		{
    			return _nodec;
    		}
    		set
    		{
    			_nodec=value;
    		}
    	}
    	public bool ShouldSerializeNodeC()
        {
            return !String.IsNullOrEmpty(_nodec.value);
        }
    }
    
    public class NodeA_Elem
    {
    	[XmlText()]
    	public string value{get;set;}
    }
    
    public class NodeB_Elem
    {
    	[XmlText()]
    	public string value{get;set;}
    }
    
    public class NodeC_Elem
    {
    	[XmlText()]
    	public string value{get;set;}
    }
     
