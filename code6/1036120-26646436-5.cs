	void Main()
	{
		Console.WriteLine(IsValid("hello"));
		Console.ReadKey();
	}
	
	public bool IsValid(string name)
	{
		Func<string, bool>[] rules = 
		{
            // Some whatever validation rules...
			n => string.IsNullOrEmpty(name),
			n => n.Length < 5 || n.Length > 50,
			n => n.Equals("hello")
		};
		return rules.All(r => r(name) == false);
	}
