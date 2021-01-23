    using System;
    using System.Net;
    using System.Threading;
    using MailKit.Net.Imap;
    using MailKit.Net.Smtp;
    using MailKit;
    using MimeKit;
    namespace TestClient {
        class Program
        {
            public static void Main (string[] args)
            {
                using (var client = new ImapClient ()) {
                    var credentials = new NetworkCredential ("jimbo", "password");
                    client.Connect (new Uri ("imaps://imap.gmail.com"), CancellationToken.None);
                    client.Authenticate (credentials, CancellationToken.None);
                    var folder = client.GetFolder (SpecialFolder.Drafts);
                    folder.Open (FolderAccess.ReadWrite, CancellationToken.None);
                    using (var smtp = new SmtpClient ()) {
                        smtp.Connect (new Uri ("smtps://smtp.gmail.com"), CancellationToken.None);
                        smtp.Authenticate (credentials, CancellationToken.None);
                        var indexes = new int[folder.Count];
                        for (int i = 0; i < folder.Count; i++) {
                            var message = folder.GetMessage (i, CancellationToken.None);
                            // if you haven't already specified a recipient, do it now:
                            message.To.Add (new MailboxAddress ("Jimbo", "jimbo@gmail.com"));
                            smtp.Send (message, CancellationToken.None);
                            indexes[i] = i;
                        }
                        // if you also want to delete the messages on the IMAP server:
                        folder.AddFlags (indexes, MessageFlags.Deleted, true, CancellationToken.None);
                        folder.Close (true, CancellationToken.None);
                        smtp.Disconnect (true, cancellationToken.None);
                    }
                    client.Disconnect (true, cancellationToken.None);
                }
            }
        }
    }
