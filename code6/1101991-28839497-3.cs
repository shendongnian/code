    EmailAddress email;
    if (contact.EmailAddresses.TryGetValue(EmailAddressKey.EmailAddress1, out email))
    {
        person.Email = GetResolvedEmailAddress(email.Address, svc);
    }
    private static Dictionary<String, String> ResolvedEmailAddressCache = new Dictionary<String, String>();
        private static String GetResolvedEmailAddress(string address, ExchangeService svc)
        {
            if (ResolvedEmailAddressCache.ContainsKey(address))
                return ResolvedEmailAddressCache[address];
    
            NameResolutionCollection nd = svc.ResolveName(address);
            foreach (NameResolution nm in nd)
            {
                if (nm.Mailbox.RoutingType == "SMTP")
                {
                    ResolvedEmailAddressCache.Add(address, nm.Mailbox.Address);
                    return nm.Mailbox.Address;
                }
            }
    
            ResolvedEmailAddressCache.Add(address, address);
            return address;
        }
