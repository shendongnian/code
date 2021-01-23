    using System.DirectoryServices.AccountManagement;
    PrincipalContext pc = new PrincipalContext(ContextType.Machine);    // Change ContextType for Domain, or AD
    var p = System.DirectoryServices.AccountManagement.AuthenticablePrincipal.FindByIdentity(pc, ".\\Mike");
    
    Console.WriteLine("{0}\\{1}", pc.ConnectedServer, p.Name);
