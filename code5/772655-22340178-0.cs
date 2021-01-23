    List<List<string>> allowed = AllowedSCACSwaps;
    foreach (List<string> c in allowed.Where(c => c.Contains(scac)))
    {
        csc = openCycles.FirstOrDefault(icsc => (icsc.CustomerCode == customerCode) && c.Contains(icsc.SCAC));
        if (null != csc)
        {
            return csc;
        }
    }
