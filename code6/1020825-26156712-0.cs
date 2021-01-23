    public static class ContactModelExtensions {
        public static ContactModel Extend(this ContactModel first, ContactModel override) {
            if (!override.ContactsName.IsNullOrEmpty()) // or whatever criteria you want
            {
                first.ContactsName = override.ContactsName;
            }
            // similar assignment for all other properties
            return first; // since we return the first one, properties not set in override
                          // will be untouched
        }
    }
