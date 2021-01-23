         	foreach (MessageAttachment ma in msg.Attachments)
			mail.Attachments.Add(BuildAttachment(ma));
 
			private Attachment BuildAttachment(MessageAttachment ma)
			{
				Attachment att = null;
				if (ma == null || ma.FileContent == null)
						return att;
				att = new Attachment(new MemoryStream(ma.FileContent), ma.FileName + ma.FileType, ma.FileType.GetMimeType());
				att.ContentDisposition.CreationDate = ma.CreationDate;
				att.ContentDisposition.ModificationDate = ma.ModificationDate;
				att.ContentDisposition.ReadDate = ma.ReadDate;
				att.ContentDisposition.FileName = ma.FileName;
				att.ContentDisposition.Size = ma.FileSize;
				return att;
			}
