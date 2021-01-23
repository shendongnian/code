    interface IImpliedReadOnly
    {
    	int SomeNumber { get; }
    }
    class Implementation : IImpliedReadOnly
    {
    	private int someNumber = 0;
    	int IImpliedReadOnly.SomeNumber
    	{
    		get { return someNumber; }
    		set { someNumber = value; }
    	}
    }
