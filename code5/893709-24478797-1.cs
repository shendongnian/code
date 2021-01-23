    using System;
    
    using MailKit.Net.Imap;
    using MailKit;
    using MimeKit;
    
    namespace TestClient {
        class Program
        {
            public static void Main (string[] args)
            {
                using (var client = new ImapClient ()) {
                    client.Connect ("imap.friends.com", 993, true);
    
                    // Note: since we don't have an OAuth2 token, disable
                    // the XOAUTH2 authentication mechanism.
                    client.AuthenticationMechanisms.Remove ("XOAUTH");
    
                    client.Authenticate ("joey", "password");
    
                    // The Inbox folder is always available on all IMAP servers...
                    client.Inbox.Open (FolderAccess.ReadOnly);
    
                    // Note: The envelope contains the date and all of the email addresses
                    var items = MessageSummaryItems.UniqueId | MessageSummaryItems.Envelope;
                    int upper = client.Inbox.Count - 1;
                    int lower = Math.Max (upper - 100, 0);
    
                    while (lower <= upper) {
                        foreach (var message in client.Inbox.Fetch (lower, upper, items)) {
                            Console.WriteLine ("Sender: {0}", message.Envelope.Sender);
                            Console.WriteLine ("From: {0}", message.Envelope.From);
                            Console.WriteLine ("To: {0}", message.Envelope.To);
                            Console.WriteLine ("Cc: {0}", message.Envelope.Cc);
                            if (message.Envelope.Date.HasValue)
                                Console.WriteLine ("Date: {0}", message.Envelope.Date.Value);
                        }
    
                        upper = lower - 1;
                        lower = Math.Max (upper - 100, 0);
                    }
    
                    client.Disconnect (true);
                }
            }
        }
    }
