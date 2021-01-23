	namespace Contracts
	{
		[ServiceContract]
		interface IMyService
		{
			[OperationContract]
			[FaultContract(typeof(MyFaultContract))]
			void MyOperation();
		}
		[DataContract]
		public class MyFaultContract
		{
			[DataMember]
			public string Problem { get; set; }
		}
		[DataContract]
		public class AnotherFaultContract
		{
			[DataMember]
			public string Description { get; set; }
		}
	}
	
