	try {
		using (Person perosn = new Person(0))
        {
            using (Person child = new Person(1))
            {
            }
        }
	} catch {
		Console.WriteLine("Caught exception");
	}
