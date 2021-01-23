	void Main()
	{
		(true && true).Then(() => Console.WriteLine("Printed out when condition == true"))
					  .Else(() => Console.WriteLine("Printed out when condition == false"));
		(true && false).Then(() => Console.WriteLine("Printed out when condition == true"))
					  .Else(() => Console.WriteLine("Printed out when condition == false"));
        Console.ReadKey();
	}
	
	public static class FunctionalExtensions
	{
		private static bool OnConditionExecute(Action doSomething)
		{
			doSomething();
			return true;
		}
		//This is executed when condition == true
		public static bool Then(this bool condition, Action doSomething)
		{
			return (condition) ? OnConditionExecute(doSomething) : false;
		}
		
		//This is executed when condition == false
		public static bool Else(this bool condition, Action doSomething)
		{
			return (condition) ? false : OnConditionExecute(doSomething);
		}
	}
