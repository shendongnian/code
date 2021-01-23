    while (true)
    {
        answer = await _inputAnswers.ReceiveAsync(TimeSpan.FromSeconds(5)); 
    					
    	if (answer.Success)
    	{
    		if (answer.Answer.Combinator.ValueType.Equals(rpccall.Combinator.ValueType))
    		{
    			break;
    		}
    		else
    		{
    			// wrong answer - post it back
    			_inputAnswers.Post(answer.Answer);
    		}
    
    	}
    	else
    	{
    		// answer fail - return it
    		break;
    	}
    }
