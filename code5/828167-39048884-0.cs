        private void SearchFromTest()
        {
            try
            {
                var _selectedMailBox = "INBOX";
                var _searchWithEmailFrom = "email@domain.com";
                using (var _clientImap4 = new Imap4Client())
                {
                    _clientImap4.ConnectSsl(_imapServerAddress, _imapPort);
                    //_clientImap4.Connect(_mailServer.address, _mailServer.port);
                    _clientImap4.Login(_imapLogin, _imapPassword); // Efetua login e carrega as MailBox da conta.
                    //_clientImap4.LoginFast(_imapLogin, _imapPassword); // Efetua login e não carrega as MailBox da conta.
                    var _mailBox = _clientImap4.SelectMailbox(_selectedMailBox);
                    // A0001 SEARCH CHARSET utf-8 BODY "somestring" OR TO "someone@me.com" FROM "someone@me.com"
                    var searchPhrase = "CHARSET utf-8 FROM \"" + _searchWithEmailFrom +  "\"";
                    foreach (var messageId in _mailBox.Search(searchPhrase).AsEnumerable())
                    {
                        var message = _mailBox.Fetch.Message(messageId);
                        var _imapMessage = Parser.ParseMessage(message);
                    }
                    _clientImap4.Disconnect();
                }
                Assert.IsTrue(true);
            }
            catch (Exception e)
            {
                Assert.Fail("Don't work.", e);
            }
        }
