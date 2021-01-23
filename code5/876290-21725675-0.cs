    class AddressComparer: IEqualityComparer<Address>
    {
        public bool Equals(Address x, Address y)
        {         
            //Check whether the compared objects reference the same data. 
            if (Object.ReferenceEquals(x, y)) return true;
            //Check whether any of the compared objects is null. 
            if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null))
                 return false;
               
            // Compare properties here. 
            // Assuming that two Addresses are equal when Street and Code are equal.
            return x.Street == y.Street && x.Code == y.Code;
        }    
        
        // If two objects are equal GetHashCode for both should return same value.
        public int GetHashCode(Address address)
        {
            if (Object.ReferenceEquals(address, null)) 
                return 0;
            int hashAddress = address.Street == null ? 0 : address.Street.GetHashCode();
            int hashCode = address.Code.GetHashCode();
    
            // Calculate new hash code from unique values combinaiton.
            return hashAddress ^ hashCode;
        }
    
    }
