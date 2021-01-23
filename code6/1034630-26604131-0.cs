	void Main()
	{
		string name;
		string city;
		int age;
		int pin;
		
		// \n is used for line-break
		Console.Write("Enter your name :  ");
		name = Console.ReadLine();
		
		Console.Write("\nEnter Your City :  ");
		city = Console.ReadLine();
		
		age = GetAge();
		
		//... eluded
	
	Console.ReadLine();
	}
	
	// Define other methods and classes here
	private int GetAge() {
		Console.Write("\nEnter your age :  ");
		int age = -1;
		while (age <0 || age>110) {
			age = Int32.Parse(Console.ReadLine());
		}
		return age;
	}
