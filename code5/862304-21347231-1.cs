    using System.Net;
    namespace NameResolution{
    public class TestUnqualifiedNameResolution {
        public DoSomething(){
            Dictionary<string, Microsoft.Xrm.Sdk.Client.Authenti‌‌​​cationCredentials> CredentialCache = new Dictionary<string, Microsoft.Xrm.Sdk.Client.Authenti‌‌​​cationCredentials>();
            //Fully qualified name is resolved to the type you are looking for, because the Dictionary does not match the name
            var credentialCache0 = System.Net.CredentialCache.DefaultCredentials;
            //Unqualified name is resolved to the nearest matching (here the Dictionary)
            var credentialCache1 = CredentialCache.DefaultNetworkCredentials;
        }
    }
    }
