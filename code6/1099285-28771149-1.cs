	MailMessage mail = new MailMessage();
	List<MailMessage> mailsToAttach = mails.FindAll(m => m.Date.CompareTo(otherDate) < 0);
	List<string> tempFiles = new List<string>();
	foreach (var item in mailsToAttach) 
	{
		string tempFile = mail.AttachMail(item);
		tempFiles.Add(tempFile);
	}
	// smtp.Send(mail)
	foreach (var item in tempFiles)
	{
		System.IO.File.Delete(item);
	}
