    private DateTime start;
    private DateTime end;
    public DateTime Start { get { return start; } }
    public DateTime End { get { return end; } }
    public void Validate()
    {
		if (end.Ticks < start.Ticks)
			throw new InvalidDates();
    }
