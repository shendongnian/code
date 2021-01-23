        private void phoneNumberChooserTask_Completed(object sender, PhoneNumberResult e)
        {
            if (e.TaskResult == TaskResult.OK)
            {
                Contacts contacts = new Contacts();
                contacts.SearchCompleted += OnContactsSearchCompleted;
                contacts.SearchAsync(e.PhoneNumber, FilterKind.PhoneNumber, null);
            }
        }
        private void OnContactsSearchCompleted(object sender, ContactsSearchEventArgs e)
        {
            if (e.Results != null)
            {
                var contactImg = e.Results.Select(x => x.GetPicture()).FirstOrDefault();
                if (contactImg != null)
                {
                    //do something with
                }
            }
        }
