	MailMessage mm1 = new MailMessage();
	mm1.IsBodyHtml = true;
	mm1.Body = ReportMsgBody;
	mm1.Subject = "Home Owner's Insurance Policy Proofs: " + lData.Select(x => x.FileName).First();
	mm1.From = new MailAddress("insurance@email.com", "FromName");
	mm1.ReplyTo = new MailAddress("insurance@email.com");
	mm1.To.Add(receiver.EmailAddress);
	foreach (NewBusinessData item in lData)
	{
		MailMessage mm = new MailMessage();
		mm.IsBodyHtml = true;
		mm.Body = HTMLBody;
		mm.Subject = "Home Owner's Insurance Policy";
		mm.From = new MailAddress("insurance@email.com", "FromName");
		mm.ReplyTo = new MailAddress("insurance@email.com");
		mm.To.Add(item.EmailAddress);
		byte[] thisAttachment;
		thisAttachment = Common.Attach(Settings.Default.FileWriterPath + item.PolicyNumber + "_" + item.MortgageLoanAccountNumber + ".pdf");
		Stream ClientPDF = new MemoryStream(thisAttachment);
		Attachment attClientPDF = new Attachment(ClientPDF, item.Pr + ".pdf", "application/pdf");
		mm.Attachments.Add(attClientPDF);
		byte[] thisAttachment2;
		thisAttachment2 = Common.Attach(Settings.Default.StaticAttatchmentPath + "Home Owner's Insurance Policy.pdf");
		Stream StaticPDF = new MemoryStream(thisAttachment2);
		Attachment attStaticPDF = new Attachment(StaticPDF, "Home Owner's Insurance Policy.pdf", "application/pdf");
		mm.Attachments.Add(attStaticPDF);
		Assembly assembly = typeof(SmtpClient).Assembly;
		Type mailWriterType = assembly.GetType("System.Net.Mail.MailWriter");
		MemoryStream stream = new MemoryStream();
		ConstructorInfo mailWriterContructor = mailWriterType.GetConstructor(BindingFlags.Instance | BindingFlags.NonPublic, null, new[] { typeof(Stream) }, null);
		object mailWriter = mailWriterContructor.Invoke(new object[] { stream });
		MethodInfo sendMethod = typeof(MailMessage).GetMethod("Send", BindingFlags.Instance | BindingFlags.NonPublic);
		sendMethod.Invoke(mm, BindingFlags.Instance | BindingFlags.NonPublic, null, new[] { mailWriter, true, true }, null);
		stream.Seek(0, SeekOrigin.Begin);
		Attachment emailAtt = new Attachment(stream, "Home Owner's Insurance Policy", "message/rfc822");
		emailAtt.TransferEncoding = System.Net.Mime.TransferEncoding.EightBit;
		mm1.Attachments.Add(emailAtt);
	}
