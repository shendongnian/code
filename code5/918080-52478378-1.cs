	void Main()
	{
		string remoteServer = "myServer";
		Console.WriteLine("GetLastBootUpTimeViaWMI");
		Console.WriteLine(GetLastBootUpTimeViaWMI(remoteServer));
		
		//code is simpler than WMI version, but requires remote management to be enabled
		Console.WriteLine("GetLastBootUpTimeViaCIM");
		Console.WriteLine(GetLastBootUpTimeViaCIM(remoteServer));
		
		Console.WriteLine("Done");
		Console.ReadKey();
	}
	
	//using System.Management
	DateTime GetLastBootUpTimeViaWMI(string computerName = ".")
	{
		//https://docs.microsoft.com/en-us/dotnet/api/system.management.managementscope?view=netframework-4.7.2
		var scope = new ManagementScope(string.Format(@"\\{0}\root\cimv2", computerName));
		scope.Connect();
		//https://docs.microsoft.com/en-us/dotnet/api/system.data.objects.objectquery?view=netframework-4.7.2
		var query = new ObjectQuery("SELECT LastBootUpTime FROM Win32_OperatingSystem");
		//https://docs.microsoft.com/en-us/dotnet/api/system.management.managementobjectsearcher?view=netframework-4.7.2
		var searcher = new ManagementObjectSearcher(scope, query);
		var firstResult = searcher.Get().OfType<ManagementObject>().First(); //assumes that we do have at least one result 
		return ManagementDateTimeConverter.ToDateTime(firstResult["LastBootUpTime"].ToString());
	}
	//using Microsoft.Management.Infrastructure
	DateTime GetLastBootUpTimeViaCIM(string computerName = ".")
	{
		var namespaceName = @"root\cimv2";
		var queryDialect = "WQL";
		var queryExpression = "SELECT LastBootUpTime FROM Win32_OperatingSystem";
		//https://msdn.microsoft.com/library/microsoft.management.infrastructure.cimsession.aspx
		var cimSession = CimSession.Create(computerName);
		return Convert.ToDateTime(cimSession.QueryInstances(namespaceName, queryDialect, queryExpression).First().CimInstanceProperties["LastBootUpTime"].Value);
	}
	
