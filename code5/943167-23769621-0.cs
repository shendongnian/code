 		[ServiceKnownType("GetKnownTypes", typeof(Helper))]
		[ServiceContract()]
		public interface IService
		{
			[OperationContract]
			IMarkerInterface GetMarker();
		}
		static class Helper 
		{
			static IEnumerable<Type> GetKnownTypes(ICustomAttributeProvider provider)
			{
				return new Type[] { typeof(CurrentBatch) };
			}
		}
