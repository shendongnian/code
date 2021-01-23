			using Rebex.Mail;
			using Rebex.Net;
			Pop3 client = new Pop3();
			client.Connect("pop.gmail.com", SslMode.Implicit);
			client.Login("gmailuser", "password");
			var messageInfos = client.GetMessageList(Pop3ListFields.FullHeaders);
			foreach (Pop3MessageInfo message in messageInfos)
				client.GetMessage(message.SequenceNumber, string.Format(@"C:\gmail-pop3-backup\{0}-{1}.eml", message.Subject, message.UniqueId));
			client.Disconnect();
