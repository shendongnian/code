	//Enable / Disable Wifi AP
	public void SetHotSpot(Boolean On)	{
		WifiManager wifiManager = (WifiManager) context.GetSystemService(Context.WifiService);
		Method[] wmMethods = wifiManager.Class.GetDeclaredMethods();
		WifiConfiguration wifiConfig = new WifiConfiguration();
		Boolean enabled = false;
		//Verify The Wifi AP State And Get The Actual Config
		foreach (Method m in wmMethods) {
			//Get Wifi AP State
			if (m.Name.Equals ("isWifiApEnabled")) {
				enabled = (Boolean) m.Invoke (wifiManager);
			}
			//Get Actual Config And Change Password
			if (m.Name.Equals ("getWifiApConfiguration")) {
				try {
					wifiConfig = (WifiConfiguration)m.Invoke (wifiManager, null);
					Random rand = new Random ();
					wifiConfig.Ssid = "Wifi Name " + rand.Next(0, 10) + rand.Next(0, 10) + rand.Next(0, 10) + rand.Next(0, 10);
					wifiConfig.PreSharedKey = "Password" + rand.Next(0, 10) + rand.Next(0, 10);
				} catch (Exception ex) {
					Log.Info (Activity, "Fail Setting New Wifi Name And Password\n\n" + ex);
				}
			}
		}
		//If Received Flag Is TRUE And Wifi AP Is Disabled, Enable It
		if (On && !enabled) {
			//Start Wifi AP With New Configuration
			foreach (Method m in wmMethods) {
				if (m.Name.Equals ("setWifiApEnabled")) {
					try {
						m.Invoke (wifiManager, wifiConfig, true);
					} catch (Exception ex) {
						Log.Info (Activity, "Fail Enabling Wifi AP\n\n" + ex);
					}
					break;
				}
			}
		}
		//If Received Flag Is FALSE And Wifi AP Is Enabled, Disable It
		else if (!On && enabled) {
			foreach(Method method in wmMethods)	{
				if(method.Name.Equals("setWifiApEnabled"))	{
					try {
						method.Invoke(wifiManager, wifiConfig, false);
					} catch (Exception ex) {
						Log.Info (Activity, "Fail Disabling Wifi AP\n\n" + ex);
					}
					break;
				}
			}
		}
	}
