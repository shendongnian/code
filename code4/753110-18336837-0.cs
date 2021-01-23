    from a in codeBase.Application.Assemblies 
    where a.AssembliesUsed.Count() >= 0 
    orderby a.AssembliesUsed.Count() descending 
    select new { 
       a,
       a.AssembliesUsed,
       a.AssembliesUsingMe
    }
