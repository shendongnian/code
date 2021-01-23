	[ComVisible(true)]
	[ClassInterface(ClassInterfaceType.None)]
	[ComDefaultInterface(typeof (IFactory))]
	[Guid("665B8F60-F39B-4E3D-ACB6-B0739FF2CF13")]
	[ProgId(MyComLibConstants.FactoryProgId)]
	public class Factory : MarshalByRefObject, IFactory
	{
		#region IFactory Members
		/// <summary>
		/// Creates the manager.
		/// </summary>
		/// <returns></returns>
		public IManager CreateManager()
		{
			return Manager.Instance;
		}
		#endregion
	}
