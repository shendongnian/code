    // new struct and generic return for items to 
	struct    _itemStruct
	{
		unsigned int id; // 0 by default, so all lists should start at 1, 0 means unassigned
		wchar_t *Name;
	};
	// for DLL lib precede void with the following... 
	// EXPORT_API 
	void getItems(std::vector<_itemStruct *> *items)
	{
		// set item list values here
		//unsigned char *bytePtr = (unsigned char*)&items; // manual pointer return
		return;
	};
	/* // In theory c# code will be...
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
	public struct _itemStruct
	{
		public unsigned int Id;
		public string Name;
	}
	[DllImport ("ListOfItems")] // for ListOfItems.DLL
	public static extern void getItems( ... ,
	[MarshalAs(UnmanagedType.Struct)] ref List<_itemStruct> items);
	// */
