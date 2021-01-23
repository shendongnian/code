    void Main()
    {
    	Console.WriteLine(AddEm());
    	
    	Console.WriteLine("Default for parm1 is " + GetDefaultParm<int>   (GetType().GetMethod("AddEm"), "parm1"));
    	Console.WriteLine("Default for parm2 is " + GetDefaultParm<int>(GetType().GetMethod("AddEm"), "parm2"));
    	Console.WriteLine("Default for parm3 is " + GetDefaultParm<int>(GetType().GetMethod("AddEm"), "parm3"));
    }
    
    private T GetDefaultParm<T>(MethodInfo m, string parmname) {
    	var parm = m.GetParameters().Where(p => p.Name == parmname).FirstOrDefault();
    	if (parm != null) {
    		return (T) parm.DefaultValue;
    	} 
    	throw new Exception("Parameter not found.");
    }	
    // Define other methods and classes here
    public int AddEm(int parm1 = 10, int parm2 = 20, int parm3 = 30) {
    	return parm1 + parm2 + parm3;
    }
