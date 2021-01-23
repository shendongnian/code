    // Or return IQueryable<CommunicationConfiguration> if you're using EF 
    // or a provider that supports it
    IEnumerable<CommunicationConfiguration> GetCommunicationConfiguration() 
    {
        return someCondition 
          ? config.PromoRegistration.Communications.Cast<CommunicationGroupConfiguration>().SelectMany(x => x.Communications).Cast<CommunicationConfiguration>()
          : config.Subscriptions.Cast<CommunicationGroupConfiguration>().SelectMany(x => x.CommunicationConfiguration).Cast<CommunicationConfiguration>();
    }
    public CommunicationConfiguration GetCurrentBrandCommunicationConfiguration() 
    {
        return GetCommunicationConfiguration()
                  .Where(x => x.CurrentBrand)
                  .FirstOrDefault();
    }
