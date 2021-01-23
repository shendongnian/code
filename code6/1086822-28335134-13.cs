	[ComVisible(true)]
	[ClassInterface(ClassInterfaceType.None)]
	[ComDefaultInterface(typeof (IFactory))]
	[Guid("...")]
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
