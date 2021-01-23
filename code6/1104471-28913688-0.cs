	/// <summary>
	/// Represents car engine.
	/// </summary>
	public interface IEngine
	{
		void Start();
	}
	/// <summary>
	/// Implement base behavior for different engine implementations.
	/// For example: Model property can be common for all your engines.
	/// </summary>
	public abstract class BaseEngine : IEngine
	{
		protected BaseEngine(string model)
		{
			if (model == null)
				throw new ArgumentNullException();
			Model = model;
		}		 
		public abstract void Start();
		public string Model { get; private set; }
	}
	/// <summary>
	/// Implement smart engine.
	/// </summary>
	public class SmartEngine : BaseEngine
	{
		public SmartEngine(string model) : base(model) { }
		public override void Start()
		{
			Console.WriteLine("SmartEngine {0} started.", Model);
		}
	}
	/// <summary>
	/// Implement turbo engine.
	/// </summary>
	public class TurboEngine : BaseEngine
	{
		public TurboEngine(string model) : base(model) { }
		public override void Start()
		{
			Console.WriteLine("TurboEngine {0} started.", Model);
		}
	}
