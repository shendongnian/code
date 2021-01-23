	   public sealed class Global
		{
			#region Singlton Contructor
			Global() { }
			static readonly Global instance = new Global();
			public static Global Default
			{
				get { return instance; }
			}
			#endregion
			#region Global Settings
			public Settings Settings {get;set;}
			private AuthenticatedUser _authenticatedUser;
			public AuthenticatedUser AuthenticatedUser
			{
				get
				{
					return _authenticatedUser;
				}
				set { _authenticatedUser = value; }
			}
			private UserSession _currentSession;
			public UserSession CurrentSession
			{
				get
				{
					if (_currentSession == null) _currentSession = UserSessionService.UserSessionFactoy();
					return _currentSession;
				}
				private set { _currentSession = value; }
			}
			#endregion
		} 
