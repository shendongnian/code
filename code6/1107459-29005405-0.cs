    using Sitecore.SecurityModel;
    .....
    Sitecore.Data.Database coredb = Sitecore.Configuration.Factory.GetDatabase("core");
    using (new SecurityDisabler())
    {
      var a = coredb.GetItem("/sitecore");
    }
