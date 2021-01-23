    ...
    using System.DirectoryServices.AccountManagement
    ...
    public class ADLDSUtility
    {
        public static ContextOptions ContextOptions = ContextOptions.SecureSocketLayer | ContextOptions.Negotiate;
        public static PrincipalContext Principal
        {
            get
            {
                return new PrincipalContext(
                   ContextType.ApplicationDirectory,
                   ConfigurationManager.AppSettings["ADLDS_Server"],
                   ConfigurationManager.AppSettings["ADLDS_Container"],
                   //you can specify username and password if need to
                   ContextOptions);
            }
        }
