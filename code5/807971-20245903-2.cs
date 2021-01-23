    public override bool Equals(Object obj)
    {
        if (obj == null)
            return false;
        CustomerLead other = obj as CustomerLead;
        if ((Object)other == null)
            return false;
        // here you need to compare two objects
        // below is just example implementation
        return this.FirstName == other.FirstName
            && this.LastName == other.LastName
            && this.EmailAddress == other.EmailAddress;
    }
