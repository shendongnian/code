    using System;            
        // has DateTime class
    using System.Collections.Generic;    
        // has the Dictionary class
    using System.DirectoryServices;    
        // has all the LDAP classes such as DirectoryEntry 
    using ActiveDs;            
        // has the IADsLargeInteger class
    // Get the root entry
    DirectoryEntry rootDSE = new DirectoryEntry("LDAP://RootDSE");
    string configurationNamingContext = 
        (string)rootDSE.Properties["configurationNamingContext"].Value;
    string defaultNamingContext = 
        (string)rootDSE.Properties["defaultNamingContext"].Value;
    // Get all the domain controllers
    // Get all the domain controllers
    DirectoryEntry deConfig = 
        new DirectoryEntry("LDAP://" + configurationNamingContext);
    DirectorySearcher dsConfig = new DirectorySearcher(deConfig);
    dsConfig.Filter = "(objectClass=nTDSDSA)";
    foreach (SearchResult srDomains in dsConfig.FindAll()) 
    {
        DirectoryEntry deDomain = srDomains.GetDirectoryEntry();
        if (deDomain != null) 
        {
            string dnsHostName = 
                deDomain.Parent.Properties["DNSHostName"].Value.ToString();
            // Get all the users for that domain
        }
    }
    // Get all the users for that domain
    DirectoryEntry deUsers = 
        new DirectoryEntry("LDAP://" + dnsHostName + "/" + defaultNamingContext);
    DirectorySearcher dsUsers = new DirectorySearcher(deUsers);
    dsUsers.Filter = "(&(objectCategory=person)(objectClass=user))";
    foreach (SearchResult srUsers in dsUsers.FindAll()) 
    {
        DirectoryEntry deUser = srUsers.GetDirectoryEntry();
        if (deUser != null) 
        {
            // Get the distinguishedName and lastLogon for each user
            // Save the most recent logon for each user in a Dictionary object
        }
    }
    //Create Dictionary
    Dictionary<string, Int64> lastLogons = new Dictionary<string, Int64>();
    // Get the distinguishedName and lastLogon for each user
    string distinguishedName = 
        deUser.Properties["distinguishedName"].Value.ToString();
    Int64 lastLogonThisServer = new Int64();
    if (deUser.Properties["lastLogon"].Value != null) 
    {
        IADsLargeInteger lgInt = 
            (IADsLargeInteger)deUser.Properties["lastLogon"].Value;
        lastLogonThisServer = ((long)lgInt.HighPart << 32) + lgInt.LowPart;
    }
    
    // Save the most recent logon for each user in a Dictionary object
    if (lastLogons.ContainsKey(distinguishedName)) 
    {
        if (lastLogons[distinguishedName] < lastLogonThisServer) 
        {
            lastLogons[distinguishedName] = lastLogonThisServer;
        }
    } 
    else 
    {
        lastLogons.Add(distinguishedName, lastLogonThisServer);
    }
    //Get the time
    // Convert the long integer to a DateTime value
    string readableLastLogon = 
        DateTime.FromFileTime(lastLogonThisServer).ToString();
