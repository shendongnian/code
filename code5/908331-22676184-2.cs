	class Caller
	{
		public static void Main(string[] args)
		{
			Callee1 c1 = new Callee1();
			Callee2 c2 = new Callee2();
			foreach (Callable c in CallManager.callables)
			{
				c.Start();
				c.OnGUI();
				c.Update();
			}
		}
	}
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
	public static class CallManager
	{
		public static HashSet<Callable> callables = new HashSet<Callable>();
	}
	public class Callee1 : Callable
	{
		public Callee1()
		{
		}
		public override void Start()
		{
			Console.WriteLine("Callee1::Start");
		}
		public override void OnGUI()
		{
			Console.WriteLine("Callee1::OnGUI");
		}
		public override void Update()
		{
			Console.WriteLine("Callee1::Update");
		}
	}
	public class Callee2 : Callable
	{
		public Callee2()
		{
		}
		public override void Start()
		{
			Console.WriteLine("Callee2::Start");
		}
		public override void OnGUI()
		{
			Console.WriteLine("Callee2::OnGUI");
		}
		public override void Update()
		{
			Console.WriteLine("Callee2::Update");
		}
	}
