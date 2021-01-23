	public class Person
	{
		public string Name { get; private set; }
		public int Age { get; private set; }
		public Person(string name, int age)
		{
			Name = name;
			Age = age;
		}
		public override string ToString()
		{
			return string.Format("Name = {0}, Age = {1}", Name, Age);
		}
	}
