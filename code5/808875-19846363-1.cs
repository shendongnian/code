    public Task<IList<IContactInfo>> SelectContacts()
    {
        ContactsSelector selector = new ContactsSelector();
        selector.ShowPicker();
        return selector.WhenContactsSelected();
    }
