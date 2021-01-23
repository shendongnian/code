	public abstract class Callable
	{
		public Callable()
		{
			OnCreate();
		}
		protected void OnCreate()
		{
			CallManager.callables.Add(this);
		}
		public abstract void Start();
		public abstract void OnGUI();
		public abstract void Update();
	}
