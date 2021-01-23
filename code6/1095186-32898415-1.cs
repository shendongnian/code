    	/// <summary>
		/// Allows caller to replace or alter the current CorsProperties on a given CloudStorageAccount.
		/// </summary>
		/// <param name="storageAccount">Storage account.</param>
		/// <param name="alterCorsRules">The returned value will replace the 
		/// current ServiceProperties.Cors (ServiceProperties) value. </param>
		public static void SetCORSPropertiesOnBlobService(this CloudStorageAccount storageAccount,
			Func<CorsProperties, CorsProperties> alterCorsRules)
		{
			if (storageAccount == null || alterCorsRules == null) throw new ArgumentNullException();
			
			CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
			ServiceProperties serviceProperties = blobClient.GetServiceProperties();
			serviceProperties.Cors = alterCorsRules(serviceProperties.Cors) ?? new CorsProperties();
			blobClient.SetServiceProperties(serviceProperties);
		}
