	public class Counter
	{
		public int Count { get; }
		
		private static int instanceCounter = 0;
		public static int InstanceCount
		{
			get
			{
				return instanceCounter;
			}
		}
		public Counter()
		{
			this.Count = instanceCounter;
			instanceCounter++;
		}
	}
