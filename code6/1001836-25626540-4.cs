    public bool IsThisMachineIsADomainController()
    {
        Domain domain = Domain.GetCurrentDomain();
        string thisMachine = String.Format("{0}.{1}", Environment.MachineName, domain.ToString());
        thisMachine = thisMachine.ToLower();
        //Enumerate Domain Controllers
        List<string> allDcs = new List<string>();
        string name = "";
        foreach (DomainController dc in domain.DomainControllers)
        {
            name = dc.Name.ToLower();
            allDcs.Add(name);
        }
        return allDcs.Contains(thisMachine);
    }
