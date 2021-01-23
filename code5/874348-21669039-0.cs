	IEnumerable<User> users =
		model
			.Select(u => new User
			{
					Username = u.Username,
					EmailAddress = u.EmailAddress,
					Federations =
						u.FederatedUsername == null
						? new List<Federation>() :
						(new []
							{
								new Federation()
								{
									FederatedUsername = u.FederatedUsername
								},
							}).ToList(),
			});
