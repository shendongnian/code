    public virtual string StackTrace
    {
    	[__DynamicallyInvokable, TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
    	get
    	{
    		return this.GetStackTrace(true);
    	}
    }
