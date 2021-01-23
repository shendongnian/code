	public class IMDB
	{
		public Dictionary<int, Person> people;
		public T RelatedID<T>(int id, IndexedMember<T> field) { ... }
		public List<T> IDRelatedIDs<T>(int key, IndexedMember<T> field) { ... }
		public void SetRelatedID<T>(int id, T newVal, IndexedMember<T> field) { ... }
	}
	public class Person
	{
		// "new IndexedMember<int>()" to initialize before first access, or
		// init upon startup (using some other manifest already maintained)
		// for less verbosity.
		public static IndexedMember<int> favoriteCelebrityID;
		public static IndexedMember<string> lastName;
		public string firstName;
	}
	public class IndexedMember<T>
	{
		// ...
	}
