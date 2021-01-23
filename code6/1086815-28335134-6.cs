    [ComVisible(true)]
	[ClassInterface(ClassInterfaceType.None)]
	[ComDefaultInterface(typeof (IManager))]
	[Guid("DAF2A948-C550-4360-8C99-EE354D593316")]
	internal sealed class Manager : MarshalByRefObject, IManager
	{
		private static Manager _instance;
		#region Constructor
		/// <summary>
		/// Prevents a default instance of the <see cref="Manager"/> class from being created.
		/// </summary>
		private Manager()
		{
			const int n = 5000;
			Array = new IArrayItem[n];
			for (int i = 0; i < n; i++)
			{
				Array[i]=new ArrayItem();
			}
		}
		#endregion
		#region Properties
		
		/// <summary>
		/// Gets the instance.
		/// </summary>
		/// <value>
		/// The instance.
		/// </value>
		public static IManager Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new Manager();
				}
				return _instance;
			}
		}
		#endregion
		#region IManager Members
		/// <summary>
		/// Gets the array.
		/// </summary>
		/// <value>
		/// The array.
		/// </value>
		public IArrayItem[] Array { get; private set; }
		#endregion
	}
