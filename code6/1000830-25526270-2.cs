    var svc = new ManagementObjectSearcher(
		scope,
		new ObjectQuery("Select Status,State from Win32_Service  where Name='My_Service_Name'"))
			.Get()
			.GetEnumerator();
        if (svc.MoveNext())
        {
              var status = svc.Current["Status"].ToString();
              var state = svc.Current["State"].ToString();
              Console.WriteLine("service status {0}", status);
              // if not running, StartService
              if (!String.Equals(state, "running",StringComparison.InvariantCultureIgnoreCase) {
                   ( (ManagementObject) svc.Current ).InvokeMethod("StartService", new object[] {});
              }
        }
        else 
        {
               Consoloe.WriteLine("service not found");
        }
