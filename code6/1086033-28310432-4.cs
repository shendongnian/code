    public interface IMyCollection : IReadOnlyList<IReadOnlyList<MyObject>>
    {
    }
	public class MyCollectionImpl : IMyCollection
	{
		private readonly IReadOnlyList<IReadOnlyList<MyObject>> _wrappedCollection;
		public MyCollectionImpl(IReadOnlyList<IReadOnlyList<MyObject>> wrappedCollection)
		{
			_wrappedCollection = wrappedCollection;
		}
		
		public int Count
		{
			get	
			{
				return _wrappedCollection.Count;
			}
		}
		
		public IReadOnlyList<MyObject> this[int index]
		{
			get	
			{
				return _wrappedCollection[index];
			}
		}
		
		public IEnumerator<IReadOnlyList<MyObject>> GetEnumerator()
		{
			return _wrappedCollection.GetEnumerator();
		}
		
		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		{
			return _wrappedCollection.GetEnumerator();
		}
	}
