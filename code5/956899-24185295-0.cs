	[Guid("4882176A-751A-4153-928A-915BEA87FAB3")]
	public class ADocument : WeinCadDocumentBase<ADocument>
	{
	    public ADocument( IWeinCadDocumentStorage storage )
	        : base(storage)
	    {
	    }
	     public override object PersistentData
	    {
	        get
	        {
	            return new DocumentData(10, 20);
	        }
	    }
	 }
