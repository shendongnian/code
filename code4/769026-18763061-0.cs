    private double RetrieveSignalString()
    {
       double theSignalStrength = 0;
       ConnectionOptions theConnectionOptions = new ConnectionOptions();
       ManagementScope theManagementScope = new ManagementScope("root\\wmi");
       ObjectQuery theObjectQuery = new ObjectQuery("SELECT * FROM MSNdis_80211_ReceivedSignalStrength WHERE active=true");
       ManagementObjectSearcher theQuery = new ManagementObjectSearcher(theManagementScope, theObjectQuery);
    
       try
       {
    
    	  //ManagementObjectCollection theResults = theQuery.Get();
    	  foreach(ManagementObject currentObject in theQuery.Get())
    	  {
    		 theSignalStrength = theSignalStrength + Convert.ToDouble(currentObject["Ndis80211ReceivedSignalStrength"]);
    	  }
       }
       catch (Exception e)
       {
    	  //handle
       }
       return Convert.ToDouble(theSignalStrength);
    }
