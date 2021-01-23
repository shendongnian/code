    Imap4Client client = new Imap4Client();
    client.Connect("server", 143);
    client.Login("***", "***");
    foreach (var box in client.AllMailboxes.OfType<Mailbox>())
    {
      for (int i = 1; i <= box.MessageCount; i++)
      {
         // a u wish
         Header heade = box.Fetch.MessageObject(i);
      }
    }
