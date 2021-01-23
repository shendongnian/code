	[ComImport]
	[InterfaceType( ComInterfaceType.InterfaceIsIUnknown )]
	[Guid( "00020D00-0000-0000-c000-000000000046" )]
	public interface IRichEditOle
	{
		int GetClientSite( IntPtr lplpolesite );
		int GetObjectCount();
		int GetLinkCount();
		int GetObject( int iob, REOBJECT lpreobject, [MarshalAs( UnmanagedType.U4 )] GetObjectOptions flags );
		int InsertObject( REOBJECT lpreobject );
		int ConvertObject( int iob, CLSID rclsidNew, string lpstrUserTypeNew );
		int ActivateAs( CLSID rclsid, CLSID rclsidAs );
		int SetHostNames( string lpstrContainerApp, string lpstrContainerObj );
		int SetLinkAvailable( int iob, int fAvailable );
		int SetDvaspect( int iob, uint dvaspect );
		int HandsOffStorage( int iob );
		int SaveCompleted( int iob, IntPtr lpstg );
		int InPlaceDeactivate();
		int ContextSensitiveHelp( int fEnterMode );
		//int GetClipboardData(CHARRANGE FAR * lpchrg, uint reco, IntPtr lplpdataobj);
		//int ImportDataObject(IntPtr lpdataobj, CLIPFORMAT cf, HGLOBAL hMetaPict);
	}
	public enum GetObjectOptions
	{
		REO_GETOBJ_NO_INTERFACES	= 0x00000000,
		REO_GETOBJ_POLEOBJ			= 0x00000001,
		REO_GETOBJ_PSTG				= 0x00000002,
		REO_GETOBJ_POLESITE			= 0x00000004,
		REO_GETOBJ_ALL_INTERFACES	= 0x00000007,
	}
	[StructLayout( LayoutKind.Sequential )]
	public struct CLSID
	{
		public int		a;
		public short	b;
		public short	c;
		public byte		d;
		public byte		e;
		public byte		f;
		public byte		g;
		public byte		h;
		public byte		i;
		public byte		j;
		public byte		k;
	}
	[StructLayout( LayoutKind.Sequential )]
	public struct SIZEL
	{
		public int	x;
		public int	y;
	}
	[StructLayout( LayoutKind.Sequential )]
	public class REOBJECT
	{
		public REOBJECT()
		{
		}
		public int		cbStruct	= Marshal.SizeOf( typeof( REOBJECT ) );     // Size of structure
		public int		cp			= 0;                                        // Character position of object
		public CLSID	clsid		= new CLSID();                              // Class ID of object
		public IntPtr	poleobj		= IntPtr.Zero;                              // OLE object interface
		public IntPtr	pstg		= IntPtr.Zero;                              // Associated storage interface
		public IntPtr	polesite	= IntPtr.Zero;                              // Associated client site interface
		public SIZEL	sizel		= new SIZEL();                              // Size of object (may be 0,0)
		public uint		dvaspect	= 0;                                        // Display aspect to use
		public uint		dwFlags		= 0;                                        // Object status flags
		public uint		dwUser		= 0;                                        // Dword for user's use
	}
	public class API
	{
		[DllImport( "User32.dll", CharSet = CharSet.Auto )]
		public static extern int SendMessage( IntPtr hWnd, int message, IntPtr wParam, IntPtr lParam );
	}
	public class Messages
	{
		public const int	WM_USER				= 0x0400;
		public const int	EM_GETOLEINTERFACE	= WM_USER + 60;
	}
	protected IRichEditOle	IRichEditOleValue	= null;
	protected IntPtr		IRichEditOlePtr		= IntPtr.Zero;
    [ComImport]
    [InterfaceType( ComInterfaceType.InterfaceIsIUnknown )]
    [Guid( "8CC497C0-A1DF-11ce-8098-00AA0047BE5D" )]
    public interface ITextDocument
    {
    // IDispath methods (We never use them)
    int GetIDsOfNames( Guid riid, IntPtr rgszNames, uint cNames, uint lcid, ref int rgDispId );
    int GetTypeInfo( uint iTInfo, uint lcid, IntPtr ppTInfo );
    int GetTypeInfoCount( ref uint pctinfo );
    int Invoke( uint dispIdMember, Guid riid, uint lcid, uint wFlags, IntPtr pDispParams, IntPtr pvarResult, IntPtr pExcepInfo, ref uint puArgErr );
    
    // ITextDocument methods
    int GetName( /* [retval][out] BSTR* */ [In, Out, MarshalAs( UnmanagedType.BStr )] ref string pName );
    int GetSelection( /* [retval][out] ITextSelection** */ IntPtr ppSel );
    int GetStoryCount( /* [retval][out] */ ref int pCount );
    int GetStoryRanges( /* [retval][out] ITextStoryRanges** */ IntPtr ppStories );
    int GetSaved( /* [retval][out] */ ref int pValue );
    int SetSaved( /* [in] */ int Value );
    int GetDefaultTabStop( /* [retval][out] */ ref float pValue );
    int SetDefaultTabStop( /* [in] */ float Value );
    int New();
    int Open( /* [in] VARIANT **/ IntPtr pVar, /* [in] */ int Flags, /* [in] */ int CodePage );
    int Save( /* [in] VARIANT * */ IntPtr pVar, /* [in] */ int Flags, /* [in] */ int CodePage );
    int Freeze( /* [retval][out] */ ref int pCount );
    int Unfreeze( /* [retval][out] */ ref int pCount );
    int BeginEditCollection();
    int EndEditCollection();
    int Undo( /* [in] */ int Count, /* [retval][out] */ ref IntPtr prop );
    int Redo( /* [in] */ int Count, /* [retval][out] */ ref IntPtr prop );
    int Range( /* [in] */ int cp1, /* [in] */ int cp2, /* [retval][out] ITextRange** */ IntPtr ppRange );
    int RangeFromPoint( /* [in] */ int x, /* [in] */ int y, /* [retval][out] ITextRange** */ IntPtr ppRange );
    }
    
    public class TomConstants
    {
    public const int	tomSuspend	= -9999995;
    public const int	tomResume	= -9999994;
    }
    
    protected ITextDocument ITextDocumentValue	= null;
    protected IntPtr		ITextDocumentPtr	= IntPtr.Zero;
