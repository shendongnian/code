	void Start()
	{
		print( "Starting " + Time.time );
		StartCoroutine( WaitPrintAndSetValue( 2.0F, theNewValue => example.Variable = theNewValue ) );
		print( "Before WaitAndPrint Finishes " + Time.time );
	}
	/// <summary>Wait for the specified delay, then set some integer value to 42</summary>
	IEnumerator WaitPrintAndSetValue( float waitTime, Action<int> setTheNewValue )
	{
		yield return new WaitForSeconds( waitTime );
		print( "WaitAndPrint " + Time.time );
		int newValueToSet = 42;
		setTheNewValue( newValueToSet );
	}
