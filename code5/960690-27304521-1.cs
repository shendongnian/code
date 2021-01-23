		[StructLayout(LayoutKind.Auto)]
		struct RADIODEVSTATE
		{
			public const int RADIODEVICES_ON = 1;
			public const int RADIODEVICES_OFF = 0;
		}
		/*
		typedef enum _RADIODEVTYPE
		{
		    RADIODEVICES_MANAGED = 1,
		    RADIODEVICES_PHONE,
		    RADIODEVICES_BLUETOOTH,
		} RADIODEVTYPE;
		 */
		[StructLayout(LayoutKind.Auto, CharSet = CharSet.Unicode)]
		struct RADIODEVTYPE
		{
			public const int RADIODEVICES_MANAGED = 1;
			public const int RADIODEVICES_PHONE = 2;
			public const int RADIODEVICES_BLUETOOTH = 3;
		}
		/*
		typedef enum _SAVEACTION
		{
		    RADIODEVICES_DONT_SAVE = 0,
		    RADIODEVICES_PRE_SAVE,
		    RADIODEVICES_POST_SAVE,
		} SAVEACTION;
		 */
		[StructLayout(LayoutKind.Auto, CharSet = CharSet.Unicode)]
		struct SAVEACTION
		{
			public const int RADIODEVICES_DONT_SAVE = 0;
			public const int RADIODEVICES_PRE_SAVE = 1;
			public const int RADIODEVICES_POST_SAVE = 2;
		}
		/*
		struct RDD 
		{
		    RDD() : pszDeviceName(NULL), pNext(NULL), pszDisplayName(NULL) {}
		    ~RDD() { LocalFree(pszDeviceName); LocalFree(pszDisplayName); }
		    LPTSTR   pszDeviceName;  // Device name for registry setting.
		    LPTSTR   pszDisplayName; // Name to show the world
		    DWORD    dwState;        // ON/off/[Discoverable for BT]
		    DWORD    dwDesired;      // desired state - used for setting registry etc.
		    RADIODEVTYPE    DeviceType;         // Managed, phone, BT etc.
		    RDD * pNext;    // Next device in list
		}; //radio device details
		 */
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		struct RDD
		{
			[MarshalAs(UnmanagedType.LPTStr)]
			public string pszDeviceName;
			[MarshalAs(UnmanagedType.LPTStr)]
			public string pszDisplayName;
			public uint dwState;
			public uint dwDesired;
			public int DeviceType;
			public IntPtr pNext;
		}
		private static bool SetDeviceState(int dwDevice, int dwState)
		{
			var pDevice = new IntPtr(0);
			//Get the first wireless device
			var result = GetWirelessDevice(ref pDevice, 0);
			if (result != 0)
				return false;
				//While we're still looking at wireless devices
				while (pDevice != IntPtr.Zero)
				{
					//Marshall the pointer into a C# structure
					var device = (RDD)System.Runtime.InteropServices.Marshal.PtrToStructure(pDevice, typeof(RDD));
					//If this device is the device we're looking for
					if (device.DeviceType == dwDevice)
					{
						//Change the state of the radio
						result = ChangeRadioState(ref device, dwState, SAVEACTION.RADIODEVICES_PRE_SAVE);
					}
					//Set the pointer to the next device in the linked list
					pDevice = device.pNext;
				}
				//Free the list of devices
				FreeDeviceList(pDevice);
			//Turning off radios doesn't correctly report the status, so return true anyway.
			return result == 0 || dwState == RADIODEVSTATE.RADIODEVICES_OFF;
		}
