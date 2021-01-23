    using (var context = new PrincipalContext(ContextType.Domain, "cat.pcsb.org"))
    {
        using (var searcher = new PrincipalSearcher(new ComputerPrincipal(context)))
        {
            foreach (var result in searcher.FindAll())
            {
                var auth = result as AuthenticablePrincipal;
                if(auth != null)
                {
                    Console.WriteLine("Name: " + auth.Name);
                    Console.WriteLine("Last Logon Time: " + auth.LastLogon);
                    Console.WriteLine();
                }
            }
        }
    }
    Console.ReadLine();
