	[ServiceContract]
	public interface IDbRepository
	{
	    [OperationContract]
	    XElement Insert(XElement entity);
	    [OperationContract]
	    XElement Update(XElement entity);
	}
