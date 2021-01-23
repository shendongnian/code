            var contactStore = await ContactManager.RequestStoreAsync();
            var contacts = await contactStore.FindContactsAsync();
            var lst = contacts.ToList();
            foreach (var contact in contacts)
            {
                var mob = contact.Phones;
                foreach (var phone in mob)
                {
                    Debug.WriteLine(phone.Kind + "-" + phone.Number);
                }
                Debug.WriteLine(contact.FirstName + " - " + contact.Addresses);
            }
