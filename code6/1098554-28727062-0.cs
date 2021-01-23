    	protected override void InitializeLastChance()
		{
			Mvx.LazyConstructAndRegisterSingleton<ISecurePersistenceService, SecurePersistenceService>();
			base.InitializeLastChance();
		}
