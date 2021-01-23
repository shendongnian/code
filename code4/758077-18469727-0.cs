         if (attachmentPaths != null && attachmentPaths.Length > 0)
        		{
        			foreach (string path in attachmentPaths)
        			{
        				if (!string.IsNullOrEmpty(path))
        				{
        				  using(Attachment data = new Attachment(path))
        				   {
        						message.Attachments.Add(data);
        				   }
        				}				
        			}
        		}
    		
    SmtpClient smtp = new SmtpClient(objBO.SmtpDomain);
    smtp.Send(message);
