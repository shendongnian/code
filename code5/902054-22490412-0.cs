	void Main()
	{
		// Enter setup code here
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
				ConsumesDelegate(DoesSomething);;
			}),
			new TimedAction("Explicit lambda", () => 
			{
				ConsumesDelegate(() => DoesSomething());
			}),        // Enter additional tests here
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
