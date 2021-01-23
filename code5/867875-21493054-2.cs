    public class CNodeString : CNode<string>
    {
    	public CNodeString(string item) : base(item) { }
    	
    	override public void Print()
    	{
    		Console.WriteLine("Printing from CNodeString");
    		base.Print();
    	}
    }
    
    public class CNodeLong : CNode<long>
    {
    	public CNodeLong(long item) : base(item) { }
    	
    	override public void Print()
    	{
    		Console.WriteLine("Printing from CNodeLong");
    		base.Print();
    	}
    }
