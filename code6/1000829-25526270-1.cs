    var svc = new ManagementObjectSearcher(
		scope,
		new ObjectQuery("Select Status from Win32_Service  where Name='My_Service_Name'"))
			.Get()
			.GetEnumerator();
        if (svc.MoveNext())
        {
              Console.WriteLine("service status {0}", svc.Current["Status"]);
        }
        else 
        {
               Consoloe.WriteLine("service not found");
        }
