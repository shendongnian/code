	string agestring = "";
	int age = 0;
	
	while ( !Int32.TryParse ( agestring, out age ) )
	{
		Console.Write ( "Please enter your age: " );
		agestring = Console.ReadLine ( );
	}
	
	if ( age >= 21 )
		Console.WriteLine ( "congrats, you can get drunk!" );
	else
		Console.WriteLine ( "Sorrrrrryyyyyyy =(" );
