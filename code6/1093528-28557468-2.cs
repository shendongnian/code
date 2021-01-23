		static void Main(string[] args)
		{
			Assembly asm = Assembly.LoadFile(@"c:\Program Files (x86)\Microsoft SQL Server\100\Setup Bootstrap\Release\x64\Microsoft.AnalysisServices.DLL");
			Module m = asm.GetModules()[0];
			var cert = m.GetSignerCertificate();
			Console.WriteLine("{0}", cert);
		}
