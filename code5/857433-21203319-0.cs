	public interface IRestriction
	{
		object Limit { get; }
	}
	public interface IRestriction<T> : IRestriction
		where T : struct
	{
		new T Limit { get; set; }
	}
	public class TimeRestriction : IRestriction<TimeSpan>
	{
		public TimeSpan Limit { get; set; }
		
		// Explicit interface member:
		// This is hidden from IntelliSense
		// unless you cast to IRestriction.
		object IRestriction.Limit
		{
			get
			{
				// Note: boxing happens here.
				return (object)Limit;
			}
		}
	}
