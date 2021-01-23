    [DllImport("oleacc.dll")]
    internal static extern int AccessibleObjectFromWindow(IntPtr hwnd, uint id, ref Guid iid, [In, Out, MarshalAs(UnmanagedType.IUnknown)] ref object ppvObject); 
    internal enum OBJID : uint
    {
        WINDOW = 0x00000000,
        SYSMENU = 0xFFFFFFFF,
        TITLEBAR = 0xFFFFFFFE,
        MENU = 0xFFFFFFFD,
        CLIENT = 0xFFFFFFFC,
        VSCROLL = 0xFFFFFFFB,
        HSCROLL = 0xFFFFFFFA,
        SIZEGRIP = 0xFFFFFFF9,
        CARET = 0xFFFFFFF8,
        CURSOR = 0xFFFFFFF7,
        ALERT = 0xFFFFFFF6,
        SOUND = 0xFFFFFFF5,
    }
	public const long UNCHECKED = 1048576;
	public const long CHECKED = 1048592;
	public const long UNCHECKED_FOCUSED = 1048580; // if control is focused
	public const long CHECKED_FOCUSED = 1048596; // if control is focused
	private static bool IsChecked(IntPtr handle) {
		Guid guid = new Guid("{618736E0-3C3D-11CF-810C-00AA00389B71}");
		Object obj = null;
		int retValue = AccessibleObjectFromWindow(handle, (uint) OBJID.CLIENT, ref guid, ref obj);
		if (obj is IAccessible) {
			IAccessible accObj = (IAccessible) obj;
			Object result = accObj.get_accState(0);
			if (result is int) {
				int state = (int) result;
				return (state == CHECKED || state == CHECKED_FOCUSED);
			}
		}
		return false;
	}
