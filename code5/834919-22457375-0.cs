	private int questCount;
	public Question Quest
	{
		get
		{
			return ServiceLocator.Current.GetInstance<Question>((++questCount).ToString());
		}
	}
