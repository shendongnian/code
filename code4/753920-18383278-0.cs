	[IntroduceMember( Visibility = Visibility.Private )]
	//public CommandFactory<TCommands> CommandFactory
	public object CommandFactory
	{
		get { return _commandFactory; }
		private set { _commandFactory = value; }
	}
