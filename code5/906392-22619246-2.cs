    public static DoSomthing()
    {
        using(var ctx = new PrincipalContext(ContextType.Domain))
        using(PrincipalSearchResult<Principal> result = GetADComputer("some Name", ctx))
        {
            //do something with the result here.
        }
    }
    public static PrincipalSearchResult<Principal> GetADComputer(string pcName, PrincipalContext ctx)
    {
        using (var computer = new ComputerPrincipal(ctx))
        {
            computer.Name = String.Format("*{0}*", pcName);
            using (var searcher = new PrincipalSearcher())
            {
                searcher.QueryFilter = computer;
                return searcher.FindAll();
            }
        }
    } 
