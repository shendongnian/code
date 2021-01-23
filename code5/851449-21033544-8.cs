    public sealed class TimeInterval
	{
		public DateTime Start { get; private set; }
		public DateTime End { get { return Start.AddMinutes(Duration); } }
		public double Duration { get; private set; }
		
		public TimeInterval(DateTime start, int duration)
		{
			Start = start;
			Duration = duration;
		}
		
		public IEnumerable<TimeInterval> Merge(TimeInterval that)
		{
			if(that.Start >= this.Start && that.Start <= this.End)
			{
				if(that.End > this.End)
					Duration += (that.Duration - (this.End - that.Start).TotalMinutes);
				
				yield return this;
			}
			else
			{		
				yield return this;
				yield return that;
			}
		}
	}	
