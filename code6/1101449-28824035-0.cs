    using System;
    using System.Reflection;
    
    public class MyService
    {
    	public void GetBySystemWarrantyId(
            string whereClause, string orderBy, 
            int start, int pageLength, 
            out int totalCount)
    	{
    		totalCount = 1;
    	}
    }
    
    public class Program
    {
    	public static void Main()
    	{
    		MethodInfo objMethoda = typeof(MyService)
                 .GetMethod("GetBySystemWarrantyId", new Type[]
    		     {
    		        typeof (string), typeof (string), 
                    typeof (int), typeof (int), 
                    typeof (int).MakeByRefType()
                 });
    		ParameterInfo[] pars = objMethoda.GetParameters();
    		foreach (ParameterInfo p in pars)
    			Console.WriteLine("{0} {1}", p.ParameterType, p.Name);
    	}
    }
