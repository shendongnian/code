	public interface IMapping<T2>
	{
		void IncludeMappingOf(Type type);
	}
	public static class MappingExtensions
	{
		public static void IncludeMappingOf<T2, T1>(this IMapping<T2> mapping)
			where T2 : T1
		{
			mapping.IncludeMappingOf(typeof(T1));
		}
	}
