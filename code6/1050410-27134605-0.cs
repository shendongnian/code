	//the following was jacked from: http://pinvoke.net/default.aspx/user32.EnumDesktopWindows
	var procCollection = new List<string>();
	//Dictionary<string, int> procCollection = new Dictionary<string, int>();
	EnumDelegate filter = delegate(IntPtr hWnd, int lParam)
	{
		//return window titles
		StringBuilder strbTitle = new StringBuilder(255);
		int nLength = GetWindowText(hWnd, strbTitle, strbTitle.Capacity + 1);
		string winTitle = strbTitle.ToString();
		//return thread process id
		uint getID = 0;
		GetWindowThreadProcessId(hWnd, ref getID);
		int winID = Convert.ToInt32(getID);
		//return class names
		StringBuilder strbClass = new StringBuilder(255);
		GetClassName(hWnd, strbClass, strbClass.Capacity+1);
		string winClass = strbClass.ToString();
		if (IsWindowVisible(hWnd) && string.IsNullOrEmpty(winTitle) == false)
		{
			procCollection.Add(winTitle+" -- "+winID+" -- "+winClass);
		}
		return true;
	};
	if (EnumDesktopWindows(IntPtr.Zero, filter, IntPtr.Zero))
	{
		//foreach (KeyValuePair<string, int> procInfo in procCollection)
		foreach(string procData in procCollection)
		{
			//if (procInfo.Key != "Start" && procInfo.Key != "Program Manager")
			if (procData.Contains("Start") == false && procData.Contains("Program Manager") == false)
			{
				lstProcesses.Items.Add(procData);
			}
		}
	}
