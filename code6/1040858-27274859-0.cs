	public class WorkItem<T>
	{
		public T Data { get; set; }
		public Func<bool> Validate { get; set; }
		public Func<T, bool> Action { get; set; }
	}
