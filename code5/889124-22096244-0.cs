    public sealed class ContactComparer : IEqualityComparer<Contact>
    {
        public bool Equals(Contact x, Contact y)
        {
            if (Object.ReferenceEquals(x, y)) return true;
    
            if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null))
                return false;
    
            return x.FirstName == y.FirstName && 
                   x.LastName == y.LastName &&
                   x.IsAdmin == y.IsAdmin;
        }
    
        public int GetHashCode(Contact contact)
        {
            if (Object.ReferenceEquals(contact, null)) return 0;
    
            //Get hash code for the Name field if it is not null. 
            int hashContactFirst = contact.FirstName == null ? 0 : contact.FirstName.GetHashCode();
    
            //Get hash code for the Code field. 
            int hashContactLast = contact.LastName == null ? 0 : contact.LastName.GetHashCode()
            int hashAdmin = contact.IsAdmin.GetHashCode();
    
            return hashContactFirst ^ hashContactLast ^ hashAdmin;
        }
    }
