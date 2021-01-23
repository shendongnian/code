    [ServiceContract]
    public interface ICarService
    {
	[OperationContract]
	List<Car> CarDetail();
    }
