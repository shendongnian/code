    using System.DirectoryServices.AccountManagement;
    using System.DirectoryServices.ActiveDirectory;
...
    using (Domain domain = Domain.GetComputerDomain())
    {
        foreach (DomainController domainController in domain.DomainControllers)
        {
            using (PrincipalContext context = new PrincipalContext(ContextType.Domain, domainController.Name))
            using (UserPrincipal userPrincipal = new UserPrincipal(context))
            using (PrincipalSearcher searcher = new PrincipalSearcher(userPrincipal))
            using (PrincipalSearchResult<Principal> results = searcher.FindAll())
            {
                foreach (UserPrincipal user in results.OfType<UserPrincipal>())
                {
                    context.ValidateCredentials(user.SamAccountName, "THEREISNOWAYTHISISTHECORRECTPASSWORD");
                }
            }
        }
    }
