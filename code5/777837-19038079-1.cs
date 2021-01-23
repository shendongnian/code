    public class Base
    {
    	
    	public virtual dynamic Parent { get {return ...}}
    
    	public virtual dynamic Connection { get {return ... ;}}
    }
    
    public class Special : Base
    {
    	
    	public override dynamic Parent { get {return MySpecialParent;}}
    
    	public override dynamic Connection { get {return new SpecialConnection();}}
    }
