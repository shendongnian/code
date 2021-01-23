    try {
	ManagementScope scope = new ManagementScope("\\\\" + computername + "\\root\\CIMV2");
	scope.Connect();
	ObjectQuery query = new ObjectQuery("SELECT * FROM Win32_NetworkAdapter WHERE Manufacturer != 'Microsoft' AND NOT PNPDeviceID LIKE 'ROOT\\\\%'");
	ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query);
	foreach (ManagementObject queryObj in searcher.Get()) {
		string ServiceName = queryObj("ServiceName");
		string ProductName = queryObj("Description");
		if (Regex.IsMatch(ServiceName, ".*NETw.*")) {
			//if we detect a wireless connection service name...
			if (Regex.IsMatch(queryObj("netenabled"), ".*true.*", RegexOptions.IgnoreCase)) {
				MessageBox.Show(ProductName + " is already enabled! [ " + queryObj("netenabled") + " ]");
			} else {
				//Try to enable the wireless connection here
				queryObj.InvokeMethod("Enable", null);
				MessageBox.Show(ProductName + " was successfully enabled!");
			}
		}
	}
    } catch (Exception ex) {
	Messagebox.show(ex.Message);
    }
