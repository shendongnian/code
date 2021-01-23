    using System.DirectoryServices.AccountManagement;
    ...
    PrincipalContext principalContext = 
         new PrincipalContext(ContextType.Domain, "192.168.1.1");
    bool userValid = principalContext.ValidateCredentials(name, password);
