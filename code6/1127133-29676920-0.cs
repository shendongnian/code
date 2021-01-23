    static void contact_item_change(object Item) {
            Microsoft.Office.Interop.Outlook.ContactItem contact = (Microsoft.Office.Interop.Outlook.ContactItem)Item;
            // Need to know if item was created by code (server) or user
            var seconds = (DateTime.Now - contact.LastModificationTime).TotalSeconds;
            if (seconds < 2) {
                System.Diagnostics.Debug.WriteLine("[Modification contact]" + contact.FullName);
                Main.SyncContact(contact);
            }
        }
