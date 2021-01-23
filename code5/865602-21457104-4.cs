    [DebuggerDisplay("{Name}")]
    public class Human
    {
    	public Human(string name, Human mom, Human dad)
    	{
    		this.Name = name;
    		this.Mom = mom;
    		this.Dad = dad;
    	}
    
    	public string Name { get; private set; }
    	public Human Mom { get; private set; }
    	public Human Dad { get; private set; }
    }
    
    public class HumanClone : Human
    {
    	public HumanClone(Human original)
    		: base(original.Name + "_Clone", null, null)
    	{
    		this.Original = original;
    	}
    
    	public Human Original { get; private set; }
    }
