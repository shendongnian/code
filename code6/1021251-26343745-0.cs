	using MultiMonitorHelper.DisplayModels.Win7.Enum;
	using MultiMonitorHelper.DisplayModels.Win7.Struct;
	
	/// <summary>
	/// Disconnect a display.
	/// </summary>
	public void DisconnectDisplay(int displayNumber)
	{
		// Get the necessary display information
		int numPathArrayElements = -1;
		int numModeInfoArrayElements = -1;
		StatusCode error = CCDWrapper.GetDisplayConfigBufferSizes(
			QueryDisplayFlags.OnlyActivePaths,
			out numPathArrayElements,
			out numModeInfoArrayElements);
		DisplayConfigPathInfo[] pathInfoArray = new DisplayConfigPathInfo[numPathArrayElements];
		DisplayConfigModeInfo[] modeInfoArray = new DisplayConfigModeInfo[numModeInfoArrayElements];
		error = CCDWrapper.QueryDisplayConfig(
			QueryDisplayFlags.OnlyActivePaths,
			ref numPathArrayElements,
			pathInfoArray,
			ref numModeInfoArrayElements,
			modeInfoArray,
			IntPtr.Zero);
		if (error != StatusCode.Success)
		{
			// QueryDisplayConfig failed
		}
		// Check the index
		if (pathInfoArray[displayNumber].sourceInfo.modeInfoIdx < modeInfoArray.Length)
		{
			// Disable and reset the display configuration
			pathInfoArray[displayNumber].flags = DisplayConfigFlags.Zero;
			error = CCDWrapper.SetDisplayConfig(
				pathInfoArray.Length,
				pathInfoArray,
				modeInfoArray.Length,
				modeInfoArray,
				(SdcFlags.Apply | SdcFlags.AllowChanges | SdcFlags.UseSuppliedDisplayConfig));
			if (error != StatusCode.Success)
			{
				// SetDisplayConfig failed
			}
		}
	}
