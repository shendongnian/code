	public class ApplicationSettings : IIdentityAppSettings, IEventStoreSettings
	{
		/* snip */
		
		static readonly object KeyLock = new object();
		
        public byte[] StsSigningKey
        {
            get
            {
                byte[] key = null;
                lock (KeyLock)
                {
                    var configManager = WebConfigurationManager.OpenWebConfiguration("/");
                    var configElement = configManager.AppSettings.Settings["StsSigningKey"];
                    if (configElement == null)
                    {
                        key = CryptoRandom.CreateRandomKey(32);
                        configManager.AppSettings.Settings.Add("StsSigningKey", Convert.ToBase64String(key));
                        configManager.Save(ConfigurationSaveMode.Modified); // save to config file
                    }
                    else
                    {
                        key = Convert.FromBase64String(configElement.Value);
                    }
                }
				
                return key;
            }
			
			/* snip */
        }
	}
