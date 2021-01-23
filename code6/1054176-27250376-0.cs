    public class ContactToMobileContactTypeConverter : ITypeConverter<Contact, MobileContact>
    {
        public MobileContact Convert(ResolutionContext context)
        {
             var contact = (Contact)context.SourceValue;
             var mobileContact = new MobileContact();
             if(contact != null) {
                 //database query
                 //assign values
             }
             return mobileContact;
        }
    }
