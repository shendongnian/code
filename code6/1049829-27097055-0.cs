    public class MySystem
    {
    	public string name;
    
    	MySystem(string name)
    	{
    		this.name = name;
    	}
    
    	public virtual void Update()
    	{
    		//dostuff
    	}
    }
    
    public class PowerSystem : MySystem
    {
    	public int totalPower;
    
    	PowerSystem (string name, int power) : base(name)
    	{
    		this.totalPower = power;
    	}
    
    	public override void Update()
    	{
    		base.Update();
    		//Do other stuff
    	}
    }
