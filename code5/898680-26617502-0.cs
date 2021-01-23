	PowerShellProcessInstance instance = new PowerShellProcessInstance(new Version(2, 0), null, null, false);
	using (Runspace rs = RunspaceFactory.CreateOutOfProcessRunspace(new TypeTable(new string[0]), instance))
	{
		rs.Open();
		using (PowerShell ps = PowerShell.Create())
		{
			ps.Runspace = rs;
			ps.AddScript("$PSVersionTable");
			dynamic vt = ps.Invoke().Single();
			Console.WriteLine(vt.PSVersion); // This will output "2.0"
        }
    }
