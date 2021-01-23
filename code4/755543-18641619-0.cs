    using (var client = new ImapClient("imap.gmail.com", 993,
             "username", "password", AuthMethod.Login, true))
            {
                var uids = client.Search(SearchCondition.Unseen());
                if (uids.Length >= 1)
                {
                    var message = client.GetMessage(uids[0], false, "inbox");
                    return new MessageInfo {EnclosedText = message.Body, Sender = message.From.ToString()};
                }
                return new MessageInfo();
            }
