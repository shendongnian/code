    public static string HackHackGetEntryText(IVsDropdownBarClient client, int iCombo, int iIndex)
    {
    	TextManagerInternal.IVsDropdownBarClient hackHackClient = (TextManagerInternal.IVsDropdownBarClient) client;
    
    	string szText = null;
    	IntPtr ppszText = IntPtr.Zero;
    
    	try
    	{
    		ppszText = Marshal.AllocCoTaskMem(Marshal.SizeOf(typeof(IntPtr)));
    		if(ppszText == IntPtr.Zero)
    			throw new Exception("Unable to allocate memory for IVsDropDownBarClient.GetTextEntry string marshalling.");
    
    		hackHackClient.GetEntryText(iCombo, iIndex, ppszText);
    
    		IntPtr pszText = Marshal.ReadIntPtr(ppszText);
    
    		szText = Marshal.PtrToStringUni(pszText);
    	}
    	finally
    	{
    		if(ppszText != IntPtr.Zero)
    			Marshal.FreeCoTaskMem(ppszText);
    	}
    
    	return szText;
    }
