	namespace BH_Server {
		[ServiceContract]
		public interface BHInterface {
			[OperationContract]
			string GetName( string name );
			[OperationContract]
			Device GetDevice();
		}
		[DataContract( Name = "Device", Namespace = "" )]
		public class Device {
		
			[DataMember( Name = "SN", Order = 1 )]
			public string SN { get; set; }
		}
	}
