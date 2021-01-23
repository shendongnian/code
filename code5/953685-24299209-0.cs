    public enum GetSubDomainOption
    {
        ExcludeWWW,
        IncludeWWW
    };
    public static class Extentions
    {
        public static string GetSubDomain(this Uri uri,
            GetSubDomainOption getSubDomainOption = GetSubDomainOption.IncludeWWW)
        {
            var subdomain = new StringBuilder();
            for (var i = 0; i < uri.Host.Split(new char[]{'.'}).Length - 2; i++)
            {
                //Ignore any www values of ExcludeWWW option is set
                if(getSubDomainOption == GetSubDomainOption.ExcludeWWW && uri.Host.Split(new char[]{'.'})[i].ToLowerInvariant() == "www") continue;
                //I use a ternary operator here...this could easily be converted to an if/else if you are of the ternary operators are evil crowd
                subdomain.Append((i < uri.Host.Split(new char[]{'.'}).Length - 3 && 
                                  uri.Host.Split(new char[]{'.'})[i+1].ToLowerInvariant() != "www") ?                     
                                       uri.Host.Split(new char[]{'.'})[i] + "." :
                                       uri.Host.Split(new char[]{'.'})[i]);
            }
            return subdomain.ToString();
        }
    }
