    public override void RegisteredForRemoteNotifications (UIApplication application, NSData deviceToken)
		{
			var oldDeviceToken = NSUserDefaults.StandardUserDefaults.StringForKey("PushDeviceToken");
			var strFormat = new NSString("%@");
			var dt = new NSString(MonoTouch.ObjCRuntime.Messaging.IntPtr_objc_msgSend_IntPtr_IntPtr(new MonoTouch.ObjCRuntime.Class("NSString").Handle, new MonoTouch.ObjCRuntime.Selector("stringWithFormat:").Handle, strFormat.Handle, deviceToken.Handle));
			var newDeviceToken = dt.ToString().Replace("<", "").Replace(">", "").Replace(" ", "");
			string sql;
			if (string.IsNullOrEmpty(oldDeviceToken) || !deviceToken.Equals(newDeviceToken))
			{
				do someting
			}
			if (oldDeviceToken == newDeviceToken) 
			{
				do someting
			} else 
			{
				do something
			}
			NSUserDefaults.StandardUserDefaults.SetString(newDeviceToken, "PushDeviceToken");
			Console.WriteLine("Device Token: " + newDeviceToken);
		}
