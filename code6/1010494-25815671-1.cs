    static Uri scannerSvcBaseAddress;
    static BasicHttpBinding scannerBinding;
    static ServiceHost scannerHost;
    public void startScannerWcfService(long eventID)
	{
		try
		{
			db.writeServiceLog(eventID, "STARTUP", "=== Scanner WCF Service Starting ===");
			string addressToHostAt = ConfigurationManager.AppSettings["ScannerHostBaseAddress"];
			if (addressToHostAt != null && addressToHostAt.Trim() != string.Empty)
			{
				scannerSvcBaseAddress = new Uri(addressToHostAt);
				scannerHost = new ServiceHost(typeof(BarCodeService.ScannerService), scannerSvcBaseAddress);
				//Allows publishing of METADATA to developers when self hosted on a remote system                 
				ServiceMetadataBehavior smb = scannerHost.Description.Behaviors.Find<ServiceMetadataBehavior>();
				if (smb == null)
				{
					smb = new ServiceMetadataBehavior();
				}
				smb.HttpGetEnabled = true;
				smb.MetadataExporter.PolicyVersion = PolicyVersion.Policy15;
				scannerHost.Description.Behaviors.Add(smb);
				scannerHost.AddServiceEndpoint(ServiceMetadataBehavior.MexContractName, MetadataExchangeBindings.CreateMexHttpBinding(), "mex");
				scannerBinding = new BasicHttpBinding();
				scannerBinding.MaxReceivedMessageSize = 2147483647;
				scannerBinding.Security.Mode = BasicHttpSecurityMode.None;
				scannerBinding.OpenTimeout = new TimeSpan(0, 0, 10);
				scannerBinding.CloseTimeout = new TimeSpan(0, 0, 10);
				scannerBinding.SendTimeout = new TimeSpan(0, 5, 0);
				scannerBinding.ReceiveTimeout = new TimeSpan(0, Global.scanUserIdleLogout * 2, 0);
				//scannerBinding.ReliableSession.InactivityTimeout = new TimeSpan(2, 0, 0, 0);
				scannerHost.AddServiceEndpoint(typeof(BarCodeService.IScannerService), scannerBinding, "");
				var behavior = scannerHost.Description.Behaviors.Find<ServiceDebugBehavior>();
				behavior.IncludeExceptionDetailInFaults = true;
				scannerHost.Open();
				db.writeServiceLog(eventID, "STARTUP", "=== Scanner WCF Service Started ===");
			}
			else
				throw new Exception("Host Base Address not provided");
		}
		catch (Exception ex)
		{
			db.writeServiceLog(eventID, "STARTUP", string.Format("Error in ServiceManager.startScannerWcfService: {0} {1}", ex.Message, ex.StackTrace));
			throw;
		}
	}
