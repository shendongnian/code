    public IMethodReturn Invoke(IMethodInvocation input, GetNextInterceptionBehaviorDelegate getNext)
    {
    	var npcAttribute = getNotifyPropertyChangedAttributeForSetter(input) as NotifyPropertyChangedAttribute;
    	if (npcAttribute != null)
    	{
    		if (npcAttribute.TimingOption == PropertyChangedTiming.Always||
    			shouldRaiseEvent(input))
    		{
    			// You are raising property changed event here, 
    			// however the value of the property is not changed until getNext()(input, getNext) called
    			// So, WPF will re-read the same "old" value and you don't see anything updated on the screen
    			raiseEvent(input);
    		}
    	}
    	
    	// Property value is updated here!!!
    	return getNext()(input, getNext);
    }
