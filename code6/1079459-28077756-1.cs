    class DoSomething
	{
		static void DoWhateverItIsThatIDo()
		{
			Console.WriteLine("You asked the abstract class to work. Too bad.");
		}
	}
    class InspireMe
	{
		static void DoWhateverItIsThatIDo()
		{
			Console.WriteLine("You are amazing.");
		}
	}
	class InsultMe
	{
		static void DoWhateverItIsThatIDo()
		{
			Console.WriteLine("You aren't worth it.");
		}
	}
	class Program
	{
		static void Main()
		{
			Action worker = InsultMe.DoWhateverItIsThatIDo;
			worker(); 
		
			worker = InspireMe.DoWhateverItIsThatIDo;
			worker();
		}
	}
