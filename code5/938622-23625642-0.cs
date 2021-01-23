    public async void FindContacts(string searchText)
        {
            ContactStore contactStore = await ContactManager.RequestStoreAsync();
            IReadOnlyList<Contact> contacts = null;
            if (String.IsNullOrEmpty(searchText))
            {
                contacts = await contactStore.FindContactsAsync();
            }
            else
            {
                contacts = await contactStore.FindContactsAsync(searchText);
            }
        }
