    void Main()
    {
    	Console.WriteLine(string.Join("", GetCharacters(@"1""2'3""4""5'6""7'8""9""A'B")));	
    }
    
    public enum CharacterType
    {
    	Other,
    	SingleQuote,
    	DoubleQuote
    }
    
    public enum State
    {
    	OutsideQuote,
    	InsideSingleQuote,
    	InsideDoubleQuote
    }
    
    public IEnumerable<char> GetCharacters(string input)
    {
    	//Initial state of the machine is OutSideQuote.
    	var sm = new StateMachine<State, CharacterType>(State.OutsideQuote);
    	
    	//Below, we configure state transitions.
    	//For a given state, we configure how CharacterType 
    	//transitions state machine to a new state.
    	
    	sm.Configure(State.OutsideQuote)
    		.Ignore(CharacterType.Other) 		
    		//If you are outside quote and you receive a double quote, 
    		//state transitions to InsideDoubleQuote.
    		.Permit(CharacterType.DoubleQuote, State.InsideDoubleQuote)
    		//If you are outside quote and you receive a single quote,
    		//state transitions to InsideSingleQuote.
    		//Same logic applies for other state transitions below.
    		.Permit(CharacterType.SingleQuote, State.InsideSingleQuote);
    		
    	sm.Configure(State.InsideDoubleQuote)
    		.Ignore(CharacterType.Other)
    		.Ignore(CharacterType.SingleQuote)
    		.Permit(CharacterType.DoubleQuote, State.OutsideQuote);
    		
    	sm.Configure(State.InsideSingleQuote)
    		.Ignore(CharacterType.Other)
    		.Ignore(CharacterType.DoubleQuote)
    		.Permit(CharacterType.SingleQuote, State.OutsideQuote);
    		
    	foreach (var character in input)
    	{
    		var characterType = GetCharacterType(character);
    		sm.Fire(characterType);
    		if(sm.IsInState(State.InsideDoubleQuote) && characterType != CharacterType.DoubleQuote)
    			yield return character;
    	}		
    
    }
    
    public CharacterType GetCharacterType(char input)
    {
        switch (input)
        {
            case '\'': return CharacterType.SingleQuote;
            case '\"': return CharacterType.DoubleQuote;
            default: return CharacterType.Other;
        }
    }
