	public class Test
	{
		private List<CustomEvent> events = new List<CustomEvent>();
		public event CustomEvent Event
		{
			add { lock(events) events.Add(value); }
			remove { lock(events) events.Remove(value); }
		}
		
		public async Task DoneSomething()
		{
			List<CustomEvent> handlers;
			lock(events) 
				handlers = this.events.ToList(); // Cache this
			var tasks = handlers.Select(s => s(this, EventArgs.Empty));
			await Task.WhenAll(tasks);
		}
	}
