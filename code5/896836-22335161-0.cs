	private void RepetitionRoutine(Movement part, Action next, int location)
	{
		part.Run(location);
			
		var timer = new DispatcherTimer();
		timer.Interval = part.duration;
		timer.Start();
		timer.Tick += (s, args) =>
			{
				next();
				timer.Stop();
			}
	}
	public class MovementChain
	{
		Action _next;
		Movement _part;
		int _location;
		public MovementChain(Movement part, int location)
		{
			_part = part;
			_location = location;
		}
		
		public void setNext(Action next)
		{
			_next = next;
		}
		
		public void execute()
		{
			RepetitionRoutine(_part, _next, _location);
		}
	}
	public void SetPlayerAnimation(int location, string endsprite, params Movement[] parts)
	{
		//Get the sprite object to be animated
		if(parts.Count() == 0)
			return;
		TranslateTarget = "Sprite" + location.ToString();
		OnPropertyChanged("TranslateTarget");	
			
		MovementChain first;
		MovementChain last;
		foreach(Movement part in parts)
		{
			MovementChain current = new MovementChain(part, location);
			if(first == null)
			{
				first = current;
				last = first;
			} 
			else
			{
				last.setNext(current.execute);
				last = current;
			}		
		}
		last.setNext(()=>SetPlayerSprite(location, endsprite));
		first.execute();
	}
