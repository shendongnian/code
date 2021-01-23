		[DataContract]
		[KnownType("GetKnownType")]  //there are few option of usage, you can apply for one concrete class: [KnownType(typeof(InheritedClass))]
		public class BaseClass
		{
			private static Type[] GetKnownType()
			{
				return return new Type[] { typeof(InheritedClass) };;
			}
		}
