    public class MyMembershipProvider : MembershipProvider
    {
         private Dictionary<string, MembershipProvider> _languageMembeshipProviders;
         public override void Initialize(string name, System.Collections.Specialized.NameValueCollection config)
        {
            ... create an SqlMembershipProvider for each language and add to
            ... the languageMembeshipProviders dictionary
        }
        public override bool ValidateUser(...)
        {
            ... Get language from HttpContext.Current somehow
            ... select a provider from the dictionary
            ... call the provider
        }
    }
