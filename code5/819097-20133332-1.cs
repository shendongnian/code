    public IMethodReturn Invoke(IMethodInvocation input, GetNextInterceptionBehaviorDelegate getNext)
    {
    	var temp = false;
    	var npcAttribute = getNotifyPropertyChangedAttributeForSetter(input) as NotifyPropertyChangedAttribute;
    	if (npcAttribute != null)
    	{
    		if (npcAttribute.TimingOption == PropertyChangedTiming.Always||
    			shouldRaiseEvent(input))
    		{
    			temp = true;
    		}
    	}
    	var returnValue = getNext()(input, getNext); // Changing the value here
    	if (temp) raiseEvent(input); // Raising property changed event, if necessary
    	return returnValue;
    }
