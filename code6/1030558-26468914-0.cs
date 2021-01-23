    public void Throw(ICallSpecification callSpecification, IEnumerable<ICall> matchingCalls, IEnumerable<ICall> nonMatchingCalls, Quantity requiredQuantity)
    {
    	StringBuilder stringBuilder = new StringBuilder();
    	stringBuilder.AppendLine(string.Format("Expected to receive {0} matching:\n\t{1}", requiredQuantity.Describe("call", "calls"), callSpecification));
    	this.AppendMatchingCalls(callSpecification, matchingCalls, stringBuilder);
    	if (requiredQuantity.RequiresMoreThan<ICall>(matchingCalls))
    	{
    		this.AppendNonMatchingCalls(callSpecification, nonMatchingCalls, stringBuilder);
    	}
    	throw new ReceivedCallsException(stringBuilder.ToString());
    }
