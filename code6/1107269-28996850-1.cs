	public class SecondClass
	{
		private readonly Holder _holder;
		public SecondClass(Holder holder)
		{
			_holder = holder;
		}
		
		public void SecondClassMethod()
		{
			_holder.Name = "John";
			Console.WriteLine(_holder.Name + " from SecondClass");
		}
	}
