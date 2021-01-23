    class ScriptParser
    {
        //Declare as member variables, to make sub-function calls simpler (not need to have "ref i", for example)
    	StringBuilder sb = new StringBuilder();
        int i;
    	string scriptString;
    
    	public string Parse(string input)
    	{
    		scriptString = input; //Share across object
    		
            //Loop through each character one at a time once
    		for (i = 0; i < scriptString.Length; i++)
    		{
			    //I suggest naming your conditions like this, especially if you're going to have more types of commands, and escape sequences in the future.
				bool isRandomCommand = (scriptString[i] == '{'); //What you have described
				bool isSomeOtherCommand = (scriptString[i] == '['); //Dummy
				bool isCommand = isRandomCommand || isSomeOtherCommand; //For later, determines whether we continue, bypassing the direct copy-through default
    			
				//Command processing
				if (isRandomCommand) //TODO: perhaps detect if the next character is double brace, in which case it's an escape sequence and we should output '{'
    				ProcessRandomCommand(); //This function will automatically update i to the end of the brace
			    else if (isSomeOtherCommand) //Dummy
					ProcessSomeOtherCommand(); //Dummy
				if (isCommand)
    				continue; //The next character could be another {} section, so re-evaluate properly
    			sb.Append(scriptString[i]); //Else, simply copy through
    		}
    		
    		return sb.ToString();
    	}
    
        void ProcessRandomCommand()
        {
    		//Find the closing brace
    		int closingBrace = scriptString.IndexOf("}", i);
    		if (closingBrace == -1)
    			throw new Exception("Closing brace not found");
    			
    		i++; //Makes the next statement nicer
    		string randomOptionsDeclaration = scriptString.SubString(i, closingBrace - i);
    		i = closingBrace; //Not closingBrace+1, because the caller will continue, and the for loop will then increment i
    		
    		string[] randomOptions = randomOptionsDeclaration.Split(',');
    		int randomIndex = 0; //TODO: Randomisation here
    		
    		sb.Append(randomOptions[randomIndex]);
        }
    }
