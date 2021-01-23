    internal class Program
	{
		private static void Main(string[] args)
		{
			Group VariousPeople = new Group();
			VariousPeople.Add(new BusinessPerson("Jack"));
		}
	}
	public abstract class Person
	{
		protected string name;
		public Person(string firstName)
		{
			name = firstName;
		}
	}
	public class BusinessPerson : Person
	{
		public BusinessPerson(string newName)
			: base(newName)
		{
		}
	}
	public class Group : CollectionBase
	{
		public void Add(Person newPerson)
		{
			List.Add(newPerson);
		}
	}
