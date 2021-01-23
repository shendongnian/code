    IPAddress address = null;
    if (IPAddress.TryParse(Request.UserHostAddress, out address))
    {
        if (IPAddress.IsLoopback(address))
        {
            address = Dns.GetHostAddresses(Dns.GetHostName()).FirstOrDefault(ip => !IPAddress.IsLoopback(ip));
            if (address == null)
            return View();
        }
        IPHostEntry entry = Dns.GetHostEntry(address);
        bool isPartOfDomain = false;
        
        foreach (IPAddress hostEntryAddress in entry.AddressList)
        {
            if (String.Equals(address.ToString(), hostEntryAddress.ToString()))
            {
                string domain = "Your Domain Here"; // or get it from your configuration settings / db / etc
                
                using (PrincipalContext domainContext = new PrincipalContext(ContextType.Domain, domain))
                {
                    string computerName = entry.HostName.Replace("." + domain, string.Empty);
                    using (ComputerPrincipal computer = ComputerPrincipal.FindByIdentity(domainContext, computerName))
                    
                     if (computer != null)
                    {
                        isPartOfDomain = true;
                        break;
                    }
                }
            }
        }
    }
