	void Main()
	{
		Version myVersion = new Version ("1.2.3.4");
		myVersion = myVersion.IncrementRevision();
		Console.WriteLine(myVersion); //1.2.3.5
		myVersion = myVersion.IncrementMinor();
		Console.WriteLine(myVersion); //1.3.0.0
	}
