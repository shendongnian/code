    public static List<ComputerInfo> GetADComputer(string pcName, PrincipalContext ctx)
    {
        using (ComputerPrincipal computer = new ComputerPrincipal(ctx))
        {
            computer.Name = String.Format("*{0}*", pcName);
            using (PrincipalSearcher searcher = new PrincipalSearcher())
            {
                searcher.QueryFilter = computer;
                using (var result = searcher.FindAll())
                {
                    return result.Select(p=> new ComputerInfo(p.Name, p.SID)).ToList();
                }
            }
        }
    } 
    public class ComputerInfo
    {
        public ComputerInfo(string name, SecurityIdentifier sid)
        {
            Name = name;
            SID = sid;
        }
        public string Name {get; set;}
        public SecurityIdentifier SID {get; set;}
    }
