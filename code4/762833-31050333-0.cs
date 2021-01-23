	public class Holder<T2>
	{
		public T2 Data { get; set; }
	}
	public static class HolderExtensions
	{
		public static void AddDataTo<T2, T1>(this Holder<T2> holder, ICollection<T1> coll)
		    where T2 : T1
		{
			coll.Add(holder.Data);   // error
		}
	}
