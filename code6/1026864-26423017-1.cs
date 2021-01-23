	Use this method to create UserEndpoint
	private UserEndpoint CreateUserEndpoint(CollaborationPlatform  _collabPlatform, String _SIP)
	{
		try
		{
			UserEndpointSettings _settings = new UserEndpointSettings(_SIP, _serverFqdn);
			_settings.SupportedMimePartContentTypes = new ContentType[] { new ContentType("text/html"), new ContentType("text/plain") };
			_settings.AutomaticPresencePublicationEnabled = true;
			UserEndpoint _userEndpoint = new UserEndpoint(_collabPlatform, _settings);
			_userEndpoint.EndEstablish(_userEndpoint.BeginEstablish(null, null));
			return _userEndpoint;
		}
		catch (Exception exx)
		{
			Console.WriteLine("\n" + _SIP + "CreateUserEndpoint : " + exx);
			return null;
		}
	}       
