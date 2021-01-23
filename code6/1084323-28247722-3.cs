    _currentVisibleCharacters = new Dictionary<UInt32, Character>();
	_currentVisibleCharacters.Add(0, new Character());
	var match = GetVisibleObject<Character>(0);
	Console.WriteLine(match);
    Console.WriteLine(match.GetType());
