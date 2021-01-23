	private IBaseFilter CreateFilter(Guid category, string name)
	{
		object source = null;
		Guid guid = typeof(IBaseFilter).GUID;
		foreach (DsDevice device in DsDevice.GetDevicesOfCat(category))
		{
			if ( device.Name == name )
			{
				device.Mon.BindToObject(null, null, ref guid, out source);
				break;
			}
		}
		return (IBaseFilter)source;
	}
	// Get device like this:
	IBaseFilter defaultSoundDevice = CreateFilter( FilterCategory.AudioInputDevice, "Default DirectSound Device" );
