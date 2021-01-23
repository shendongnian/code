    class MaliciousSmall
    {
    	public MaliciousSmall()
    	{
    		//
    	}
    
    	public MaliciousSmall(DataRow row)
    	{
    		//
    	}
    }
    
    class Malicious:MaliciousSmall
    {
    	public Malicious()
    	{
    		//
    	}
    
    	public Malicious(DataRow row):base(row)
    	{
    		//
    	}
    }
    
    Malicious obj = new Malicious();
