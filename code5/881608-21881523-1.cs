    public static class BusinessLogic
    {
        public static string GetContactName(string companyName)
        {
            var c = new Customer () ... // get you Customer-object
    
            var q = (from contacts in c.CustomerContacts
                    where contacts.CompanyName == companyName
                    select contacts.ContactName).First();
    
            return q;
        }
    }
