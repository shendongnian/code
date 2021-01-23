    public static class CustomMapper
    {
        public static void leadToContact(Lead lead, ID contactID)
        {
            var contact = new Contact(contactID);
            ///do mapping here
            ///eg
            ///returnval.Newsletter__c = Lead.Newsletter__c;
        
            contact.save();
        }
    }
