    Func<AccessControlEntry,bool> hasFullAccess = (ace => ace.AccessMask % 2 == 1);
    // cast usrAcl as required get IEnumerable<AccessControlEntry>
    foreach (var ace in usrAcl.Where(hasFullAccess))
    {
    }
