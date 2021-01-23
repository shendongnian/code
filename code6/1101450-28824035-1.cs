    using System;
    using System.Reflection;
    
    public class MyService
    {
    	public void GetBySystemWarrantyId(string whereClause, string orderBy, 
            int start, int pageLength, out int totalCount)
    	{
    		totalCount = 1234567890;
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
                    typeof (int), typeof (int), typeof (int).MakeByRefType()
                 });
    		MethodInfo objMethodb = typeof(MyService)
                 .GetMethod("GetBySystemWarrantyId");
			
			int count= -1;
			object[] args = new object[] { "", "", 1, 1, count };
			
			objMethoda.Invoke(new MyService(), args);
			Console.WriteLine(args[4]);
			
			objMethodb.Invoke(new MyService(), args);
			Console.WriteLine(args[4]);
    	}
    }
