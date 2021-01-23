	public class MyCollection<T> where T : MyBaseObject 
	{
		public void Add(T obj)
		{
			/* no need to cast to T, just insert */
		}
	}
