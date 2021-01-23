    public static int ContactSearchFirst(List<Contact> contactList,
                                         string userInput)
    {
        return contactList
            .FindIndex(c => 
                c.FirstName.Equals(userInput,
                                   StringComparison.InvariantCultureIgnoreCase));
    }
