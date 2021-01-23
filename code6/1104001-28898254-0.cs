    public static void Main()
	{
		var derived = new Derived();
	}
	
	public class Base
	{
		protected string _p = "Base";
		public virtual string P
		{			
			get
			{
				Console.WriteLine("Base get");
				return _p;
			}
			set
			{
				Console.WriteLine("Base set");
				_p = value;
			}
		}
		
		public Base()
		{
			P = "Base constructor";
		}
	}
	
	public class Derived : Base
	{
		public override string P
		{			
			get
			{
				Console.WriteLine("Derived get");
				return _p;
			}
			set
			{
				Console.WriteLine("Derived set");
				_p = value;
			}
		}
        public Derived()
		{
			Console.WriteLine(P);
		}
	}
