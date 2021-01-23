    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [BasicHttpBindingServiceMetadataExchangeEndpoint]
    public class Client : IClient
    {
        public bool Subscribe(string emailAddress, string firstName, string lastName, string[] groups)
        {
            //do something
            return true;
        }
    }
