    public class CustomService : ServiceBase
    	protected override void OnSessionChange(SessionChangeDescription desc)
    	{
            switch (desc.Reason)
            {
                case SessionChangeReason.SessionLogon:
					var user = CustomService.UserInformation(desc.SessionId);
					CustomService.DoWhatEverYouWant(user);
				break;
			}	
    	}
    
    	private static User UserInformation(int sessionId)
    	{
    		IntPtr buffer;
    		int length;
    
    		var user = new User();
    
    		if (NativeMethods.WTSQuerySessionInformation(IntPtr.Zero, sessionId, NativeMethods.WTS_INFO_CLASS.WTSUserName, out buffer, out length) && length > 1)
    		{
    			user.Name = Marshal.PtrToStringAnsi(buffer);
    			
    			NativeMethods.WTSFreeMemory(buffer);
    			if (NativeMethods.WTSQuerySessionInformation(IntPtr.Zero, sessionId, NativeMethods.WTS_INFO_CLASS.WTSDomainName, out buffer, out length) && length > 1)
    			{
    				user.Domain = Marshal.PtrToStringAnsi(buffer);
    				NativeMethods.WTSFreeMemory(buffer);
    			}
    		}
    
    		if (user.Name.Length == 0)
    		{
    			return null;
    		}
    		
    		return user;
    	}
    }
