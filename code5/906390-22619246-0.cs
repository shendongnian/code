    public static DoSomthing()
    {
        using(PrincipalContext ctx = new PrincipalContext(ContextType.Domain))
        {
            var result = GetADComputer("some Name", ctx);
            //do something with the result.
        }
    }
    public static PrincipalSearchResult<Principal> GetADComputer(string pcName, PrincipalContext ctx)
    {
        using (ComputerPrincipal computer = new ComputerPrincipal(ctx))
        {
            computer.Name = String.Format("*{0}*", pcName);
            using (PrincipalSearcher searcher = new PrincipalSearcher())
            {
                searcher.QueryFilter = computer;
                return searcher.FindAll();
            }
        }
    } 
