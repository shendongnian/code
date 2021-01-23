	[ComVisible(true)]
	[InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
	public interface IArrayItem
	{
		#region Properties
		string Name { get; set; }
		int Whatsit { get; set; }
		#endregion
	}
	[ComVisible(true)]
	[InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
	public interface IFactory 
	{
		#region Methods
		IManager CreateManager();
		#endregion
	}
	[ComVisible(true)]
	[InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
	public interface IManager
	{
		#region Properties
		IArrayItem[] Array { get; }
		#endregion
	}
	public static class MyComLibConstants
	{
		public const string FactoryProgId = "MickyD.MyComLib.Factory.1";
		
	}
