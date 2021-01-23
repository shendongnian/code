    string cc = customerCode.ToUpperInvariant();
    string sc = scac.ToUpperInvariant();    List<List<string>> allowed = AllowedSCACSwaps;
        foreach (List<string> c in allowed.Where(c => c.Contains(sc)))
        {
            csc = openCycles.FirstOrDefault(icsc => (icsc.CustomerCode == cc) && c.Contains(icsc.SCAC));
            if (null != csc)
            {
                return csc;
            }
        }
