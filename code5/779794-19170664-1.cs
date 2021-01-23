    static void Main(string[] args)
    { 
        ServicePointManager.ServerCertificateValidationCallback = delegate(Object obj, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
        {
            if (errors == System.Net.Security.SslPolicyErrors.None)
            {
                return true;
            }
 
            if ((errors & System.Net.Security.SslPolicyErrors.RemoteCertificateChainErrors) != 0)
            {
                if (chain != null && chain.ChainStatus != null)
                {
                    foreach (System.Security.Cryptography.X509Certificates.X509ChainStatus status in chain.ChainStatus)
                    {
                        if ((certificate.Subject == certificate.Issuer) &&
                           (status.Status == System.Security.Cryptography.X509Certificates.X509ChainStatusFlags.UntrustedRoot))
                        {
                            continue;
                        }
                        else
                        {
                            if (status.Status != System.Security.Cryptography.X509Certificates.X509ChainStatusFlags.NoError)
                            {
 
                                return false;
                            }
                        }
                    }
                }
 
                return true;
            }
            else
            {
                return false;
            }
        }; 
 
        ExchangeService _service = new ExchangeService(ExchangeVersion.Exchange2010);
        _service.Credentials = new WebCredentials("user", "password");
        _service.Url = new Uri("https://mail.domain.com/ews/exchange.asmx");
 
        //Contact mailbox
        ContactsFolder contactsfolder = ContactsFolder.Bind(_service, WellKnownFolderName.Contacts);
 
        int numItems = contactsfolder.TotalCount < int.MaxValue ? contactsfolder.TotalCount : int.MaxValue;
 
        ItemView view = new ItemView(numItems);
 
        view.PropertySet = new PropertySet(BasePropertySet.IdOnly, ContactSchema.DisplayName);
 
        FindItemsResults<Item> contactItems = _service.FindItems(WellKnownFolderName.Contacts, view);
 
        foreach (Item item in contactItems)
        {
            if (item is Contact)
            {
                Contact contact = item as Contact;
                Console.WriteLine(contact.DisplayName);
            }
        }
 
        Console.ReadLine();
    }
