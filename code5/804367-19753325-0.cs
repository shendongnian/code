    class Employee
    {
    	public virtual string Infos { get; set; }
    }
    
    class Engineer : Employee
    {
    	public override string Infos { get; set; }
    	
    	public void M()
    	{
    		this.Infos = "Name : Boulkriat Brahim";
    		Console.WriteLine(base.Infos);
    	}
    }
