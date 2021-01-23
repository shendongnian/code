    System.Exchange.WebServices.Data.Item email = new System.Exchange.WebServices.Data.Item(myEmail);
    OpenPop.Mime.Message message = new OpenPop.Mime.Message(email.MimeContent.Content);
    List<OpenPop.Mime.MessagePart> validMessageParts = message.FindAllAttachments().Where(x => x.FileName.Contains(".csv") == true || x.FileName.Contains(".xlsx") == true || x.FileName.Contains(".xls") == true).ToList<MessagePart>();
    foreach (MessagePart messagePart in validMessageParts)
    {
      if (messagePart != null)
      {
        using (FileStream fileStream = new FileStream(savingPath + messagePart.ContentDisposition.FileName, FileMode.Create, FileAccess.ReadWrite))
        {
            messagePart.Save(fileStream);
        }
      }
    }
