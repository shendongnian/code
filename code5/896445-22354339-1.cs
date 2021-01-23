    class MaliciousSmall
    {
    	public MaliciousSmall(DataRow row)
    	{
    		//compiler will not supply a default constructor
    	}
    }
    
    class Malicious: MaliciousSmall
    {
    	//if no constructors are defined then compiler adds the following
    	//public Malicious() : base()
    }
    
    Malicious obj = new Malicious();
