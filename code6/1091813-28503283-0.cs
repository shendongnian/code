    interface IObjectReturnable<T>
	{
		T GetSomeObject();
	}
	public class ObjectClassRet : IObjectReturnable<ObjectClassRet>
	{
		public ObjectClassRet GetSomeObject()
		{
			// method implementation here
			return new ObjectClassRet();
		}
	}
