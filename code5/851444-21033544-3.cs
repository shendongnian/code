    public IEnumerable<TimeInterval> Merge(IEnumerable<TimeInterval> spans, int duration)
	{
		var stack = new Stack<TimeInterval>();
		
		stack.Push(spans.First());
		
		foreach (var span in spans.Skip(1))
			foreach(var interval in stack.Pop().Merge(span))
				stack.Push(interval);
		
		return from interval in stack where interval.Duration >= duration select interval;
	}
	
	
