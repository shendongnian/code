    using Windows.Phone.PersonalInformation;
    public async void addPerson() {
        var store = await ContactStore.CreateOrOpenAsync();
        var contact = new StoredContact(store) {
            DisplayName = "Mike Peterson"
        };
        var props = await contact.GetPropertiesAsync();
        props.add(KnownContactProperties.Email, "mike@peterson.com");
        props.add(KnownContactProperties.MobileTelephone, "+1 212 555 1234");
        await contact.SaveAsync();
    }
