	using System;
	using System.IO;
	using System.Reflection;
	using System.Windows.Forms;
	namespace TestAsembly
	{
		static class Program
		{
			[STAThread]
			static void Main(string[] args)
			{
				AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;
				//bla-bla...
			}
			static Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
			{
				if (args.Name.StartsWith("Library,"))
				{
					Assembly asm = Assembly.LoadFrom("Library222.dll");
					return asm;
				}
				return null;
			}
		}
	}
