    public static class ContactModelExtensions {
        public static ContactModel Extend(this ContactModel first, ContactModel replacement) {
            if (!replacement.ContactsName.IsNullOrEmpty()) // or whatever criteria you want
            {
                first.ContactsName = replacement.ContactsName;
            }
            // similar assignment for all other properties
            return first; // since we return the first one, properties not set in override
                          // will be untouched
        }
    }
