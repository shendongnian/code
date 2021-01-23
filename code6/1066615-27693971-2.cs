    void processNotification(NSDictionary options, bool fromFinishedLaunching)
		{
			if (null != options && options.ContainsKey(new NSString("aps")))
			{
				NSDictionary aps = options.ObjectForKey(new NSString("aps")) as NSDictionary;
				string alert = string.Empty;
				string sound = string.Empty;
				int badge = -1;
				if (aps.ContainsKey(new NSString("alert")))
					alert = (aps[new NSString("alert")] as NSString).ToString();
				if (aps.ContainsKey(new NSString("sound")))
					sound = (aps[new NSString("sound")] as NSString).ToString();
				if (aps.ContainsKey(new NSString("badge")))
				{
					string badgeStr = (aps[new NSString("badge")] as NSObject).ToString();
					int.TryParse(badgeStr, out badge);
				}
				if (!fromFinishedLaunching) 
				{
					if (badge >= 0)
						UIApplication.SharedApplication.ApplicationIconBadgeNumber = badge;
						
					if (sound == "xx.caf") 
					{
						UIAlertView avAlert = new UIAlertView ("Dogrular App", alert, null, "Tamam", null);
						avAlert.Show ();
					}
					if (sound == "yyy.caf") 
					{
						UIAlertView avAlert = new UIAlertView ("Dogrular App", alert, null, "Tamam", null);
						avAlert.Show ();
						NSUrl request = new NSUrl("https://xxx.com");
						UIApplication.SharedApplication.OpenUrl(request);
					}
				}
			}
		}
