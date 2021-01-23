    public class RefDataProvider : IRefDataProvider
    {            
		private readonly ICrmServiceClient crmServiceClient;
		public RefDataProvider(ICrmServiceClient crmServiceClient)
		{
			this.crmServiceClient = crmServiceClient;
		}
        public IEnumerable<CountryLookupDto> GetCountries()
        {
			/* your code */
        }
	}
