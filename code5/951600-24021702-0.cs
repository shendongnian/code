    public class ProgChoice
    {
    
    	public static void ProgSelection()
    	{
    
    
    			Assembly assembly = Assembly.GetExecutingAssembly();
    
    			Type t = assembly.GetType("ProgChoice.ProgSelection", false, true);
    
    						string lcProgStr = "Prog";
    						int liProgNumb = 4;
    
    						lcProgStr = lcProgStr + liProgNumb.ToString();// Concatenate the 2 strings
    
    			MethodInfo method = t.GetMethod(lcProgStr);
    			method.Invoke(null, null);
    
    			Console.ReadKey();
    
    
    	}
    
    
    	public static void Prog4()
    	{
    
    	}
    
    }
