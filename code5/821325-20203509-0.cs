    public List<Contact> FilterContacts(Contact con)
    {
        var copy = new List<Contact>();
        foreach (Contact cn in Contacts)
        {
            if (cn.number == con.number)
                copy.add(cn);
            else
                if (cn.name == con.name)
                    copy.add(cn);
        }
        return copy;
    }
