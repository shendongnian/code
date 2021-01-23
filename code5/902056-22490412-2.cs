	void Main()
	{
		// Enter setup code here
		Func<object> cachedDoesSomething = DoesSomething;
		var actions = new[]
		{
			new TimedAction("No-op", () => 
			{
			}),
			new TimedAction("method call", () => 
			{
				DoesSomething();
			}),
			new TimedAction("ForceDelegateConsumption", () => 
			{
				ForceDelegateConsumption();
			}),
			new TimedAction("ForceDelegateConsumptionInline", () => 
			{
				ConsumesDelegate(DoesSomething);
			}),
			new TimedAction("DoesSomethingInlined", () => 
			{
				ConsumesDelegate(() => null);
			}),
			new TimedAction("CachedLambda", () => 
			{
				ConsumesDelegate(cachedDoesSomething);
			}),
			new TimedAction("Explicit lambda", () => 
			{
				ConsumesDelegate(() => DoesSomething());
			}),   
		};
		const int TimesToRun = 10000000; // Tweak this as necessary
		TimeActions(TimesToRun, actions);
	}
	public void ConsumesDelegate (Func<object> consumer) { 
		consumer();
	}
	public object DoesSomething() { return null; }
	public void ForceDelegateConsumption()
	{
		ConsumesDelegate(DoesSomething);
	}
