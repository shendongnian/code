	using System;
	using System.Net;
	namespace ConsoleApplication {
		class Program {
			static void Main()
			{
                        	// That's a System.Int32!
				int a = System.Net.CredentialCache;
				Console.WriteLine("{0} == System.Int32", a.GetType().FullName);
				Console.ReadKey();
			}
			public static class System
			{ 
				public static Net Net { get { return new Net(); } }
			}
			public class Net
			{
				public int CredentialCache { get { return 0; } }
			}
		}
	}
