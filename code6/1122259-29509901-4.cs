	using System.Collections.Generic;
	using System.ServiceModel;
	namespace WcfService1
	{
		[ServiceContract(SessionMode = SessionMode.Required)]
		public interface IService1
		{
			[OperationContract]
			int AddData(string data);
			[OperationContract]
			List<string> GetData();
		}
		[ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
		public class Service1 : IService1
		{
			private readonly List<string> _myList = new List<string>();
			public int AddData(string data)
			{
				_myList.Add(data);
				return _myList.Count;
			}
			public List<string> GetData()
			{
				return _myList;
			}
		}
	}
