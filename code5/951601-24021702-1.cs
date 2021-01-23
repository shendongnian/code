    public class ProgChoice
    {
    	public static void ProgSelection()
    	{
            Assembly assembly = Assembly.GetExecutingAssembly();
    
    	    Type t = assembly.GetType("ProgChoice.ProgSelection", false, true);
    
    	    string lcProgStr = "Prog";
            int liProgNumb = 4;
    
            // Concatenate the 2 strings
    	    lcProgStr = lcProgStr + liProgNumb.ToString();
    
    	    MethodInfo method = t.GetMethod(lcProgStr);
    	    method.Invoke(null, null);
    
    	    Console.ReadKey();
    	}
    }
