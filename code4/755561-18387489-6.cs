    private void ContactResultsData_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        Contact contact = ContactResultsData.SelectedItem as Contact;
        if (contact != null)
        {
            CustomContact customContact = new CustomContact(contact);
        }
    }
