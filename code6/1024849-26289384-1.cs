    using System;
	using System.Linq;
	using System.Reflection;
	
	public class Program
	{
		public static void Main()
		{	
			// Test Data
			DoProduct(31);		
			DoProduct(63);	
			DoProduct(49);
			DoProduct(49);
			DoProduct(61);
		}
		
		public static void DoProduct(int productId)
		{
			string data = "";
			bool methodExecuted = false;
			
			// I am loading the string "data" with test data for simplicity.
			// In real life, you'll load this from your file intead.
			data = data + "31 MyFirstFunction" + Environment.NewLine;
			data = data + "49 MySecondFunction" + Environment.NewLine;
			data = data + "63 MyThirdFunction" + Environment.NewLine;
			
			foreach (string str in data.Replace(Environment.NewLine, "\n").Replace('\r', '\n').Split('\n'))
			{
				if (string.IsNullOrEmpty(str))
					continue;
				
				int pid = int.Parse(str.Split(' ')[0]);
				string func = str.Split(' ')[1];
				
				if (pid != productId)
					continue;
				
				Type type = typeof(Program);
				
				MethodInfo[] methods = type.GetMethods(BindingFlags.Static | BindingFlags.Public);
				
				MethodInfo method = methods.FirstOrDefault(z => z.Name.Equals(func));
				if (method == null) {
					continue;
				}
				
				method.Invoke(null, null);	
				methodExecuted = true;
			}
			
			if (!methodExecuted)
			{
				MyDefaultFunction();
			}
		}
		
		public static void MyFirstFunction() 
		{
			Console.WriteLine("This is MyFirstFunction()!");
		}
		
		public static void MySecondFunction() 
		{
			Console.WriteLine("This is MySecondFunction()!");
		}
		
		public static void MyThirdFunction() 
		{
			Console.WriteLine("This is MyThirdFunction()!");
		}
		
		public static void MyDefaultFunction() 
		{
			Console.WriteLine("This is MyDefaultFunction()!");
		}
	}
