    void Main()
    {
    	DerivedHide d1 = new DerivedHide();
    	Console.WriteLine(d1.GetName()); // "DerivedHide"
    	Base b = d1;
    	Console.WriteLine(b.GetName());  // "Base"
    	
        DerivedOverride d2 = new DerivedOverride();
    	Console.WriteLine(d2.GetName());// "DerivedOverride"
    	b = d2;
    	Console.WriteLine(b.GetName()); // "DerivedOverride"
    }
    
    public class Base
    {
    	public virtual string GetName(){ return "Base"; }
    }
    
    public class DerivedHide : Base
    {
    	public string GetName() { return "DerivedHide"; } // causes compiler warning
    }
    
    public class DerivedOverride : Base
    {
    	public override string GetName() { return "DerivedOverride"; }
    }
