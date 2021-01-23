    private void DeleteMessages () 
    {
        using (var client = new ImapClient ()) {
            client.Connect ("imap-mail.outlook.com", 993, true);
            client.Authenticate ("mail", "password");
            client.Inbox.Open (FolderAccess.ReadWrite);
            // Search for messages that match the From address.
            var uids = client.Inbox.Search (SearchQuery.FromContains (txtMailToDelete.Text));
            // Mark the messages for deletion.
            client.Inbox.AddFlags (uids, MessageFlags.Deleted, true);
            // if the server supports the UIDPLUS extension, issue a "UID EXPUNGE"
            // command to purge the messages we just marked for deletion.
            if (client.Capabilities.HasFlag (ImapCapabilities.UidPlus))
                client.Inbox.Expunge (uids);
            client.Disconnect (true);
        }
    }
