    [NotMapped]
    public int CountUnreadMessages 
	{
		get
		{
			return Messages.Count(x => !x.Read);
		}
	}
