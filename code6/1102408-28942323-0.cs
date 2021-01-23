	public WizardPage1ViewModel : ViewModel 
	{
		private IConfigurationService configService;
		
		public WizardPage1ViewModel(IConfigurationService configService) 
		{
			this.configService = configService;
		}
		
		public string InstallationPath 
		{
			get { return this.configService.InstallationPath; }
			set 
			{
				if(path!=value) 
				{
					this.configService.InstallationPath = value;
					
					OnPropertyChanged("InstallationPath");
				}
			}
		}
	}
