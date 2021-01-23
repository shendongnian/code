    public class Dog
	{
		public string Id { get; set; }
		public string Name { get; set; }
		public int BarksOut { get; set; }
		public int RunOuts { get; set; }
		public Dog(string name, string id)
		{
			Name = name;
			Id = id;
		}
		public void Bark(int barksNumber)
		{
			for(var i =0; i < barksNumber; i++)
				Console.WriteLine("{0} >> {1} is barking", Id, Name);
			BarksOut += barksNumber;
		}
		public void Run(int runs)
		{
			for (var i = 0; i < runs; i++)
				Console.WriteLine("{0} >> {1} is running", Id, Name);
			RunOuts += runs;
		}
		public void Lie(long lies)
		{
			if (lies == 0)
				return;
			for (var i = 0; i < lies; i++)
				Console.WriteLine("{0} >> {1} if lying", Id, Name);
		}
	}
