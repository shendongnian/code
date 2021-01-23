    public class Base
    {
    	
    	public virtual Base Parent { get {return ...}}
    
    	public virtual BaseConnection Connection { get {return ... ;}}
    }
    
    public class Special : Base
    {
    	
    	public override Base Parent { get {return MySpecialParent;}}
    
    	public override BaseConnection Connection { get {return new SpecialConnection();}}
    }
