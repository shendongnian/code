	void Main()
	{
		Person instance1=new SpecificPerson();
		instance1.Execute();//Person
		
		SpecificPerson instance2=new SpecificPerson();
		instance2.Execute();//Specific
	}
		public class Person
		{
			public void Execute()
			{
				Console.WriteLine("Person");
			}
		}
		public class SpecificPerson:Person
		{
			public void Execute()
			{
				Console.WriteLine("Specific");
			}
		}
