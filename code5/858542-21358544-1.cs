    using System;
    using System.Net;
    using System.Threading;
    using MailKit.Net.Imap;
    using MailKit.Search;
    using MailKit;
    using MimeKit;
    namespace TestClient {
        class Program
        {
            public static void Main (string[] args)
            {
                using (var client = new ImapClient ()) {
                    var credentials = new NetworkCredential ("xxx@hotmail.com", "xxx");
                    var uri = new Uri ("imaps://imap-mail.outlook.com");
                    using (var cancel = new CancellationTokenSource ()) {
                        client.Connect (uri, cancel.Token);
                        client.Authenticate (credentials, cancel.Token);
                        // Open the Inbox folder
                        client.Inbox.Open (FolderAccess.ReadOnly, cancel.Token);
                        var query = SearchQuery.FromContains ("xxx@yahoo.com");
                        foreach (var uid in client.Inbox.Search (query, cancel.Token)) {
                            var message = client.Inbox.GetMessage (uid, cancel.Token);
                        }
                        client.Disconnect (true, cancel.Token);
                    }
                }
            }
        }
    }
