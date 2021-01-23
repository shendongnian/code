    class Site : IEntity, IAggregate {
      public SiteKey Key {get}
    
      public CompanyKey CompanyKey {get}
      public ContactKey PrimaryContactKey {get}
      public IEnumerbale<ContactKey> ContactKeys {get}
      public string SiteName {get}
      //--domain logic here
      / ..
    }
