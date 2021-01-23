    using System;
	using System.Net.Mail;
	using System.IO;
	using Outlook = Microsoft.Office.Interop.Outlook;
	namespace MailAttachment
	{
		public static class Extensions
		{
			public static string AttachMail(this MailMessage mail, MailMessage otherMail)
			{
	            string path = Path.GetTempPath(),
	            	tempFilename = Path.Combine(path, Path.GetTempFileName());
				Outlook.Application outlook = new Outlook.Application();
	            Outlook.MailItem outlookMessage;
	            outlookMessage = outlook.CreateItem(Outlook.OlItemType.olMailItem);
	            foreach (var recv in message.To)
	            {
	                outlookMessage.Recipients.Add(recv.Address);
	            }
	            outlookMessage.Subject = mail.Subject;
	            if (message.IsBodyHtml)
	            {
	                outlookMessage.BodyFormat = Outlook.OlBodyFormat.olFormatHTML;
	                outlookMessage.HTMLBody = message.Body;
	            }
	            else
	            {
	            	outlookMessage.Body = message.Body;
	            }
	            outlookMessage.SaveAs(tempFilename);
	            outlookMessage = null;
	            outlook = null;
	            Attachment attachment = new Attachment(tempFilename);
	            attachment.Name = mail.Subject + ".msg";
	            otherMail.Attachments.Add(attachment);
	            return tempFilename;
			}
		}
	}
