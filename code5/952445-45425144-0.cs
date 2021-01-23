    FindItemsResults<Item> findResults = exchange.FindItems(WellKnownFolderName.Inbox, newItemView(50,50));
    Item[] msgItems = findResults.Where(msgItem => msgItem.HasAttachments).ToArray();
    EmailMessage msgInfo = null;
    var fileExtensions = new List<string> { "msg", "MSG", "Msg" };
        foreach (MSEWS.Item msgItem  in msgItems )
        {
          msgInfo = EmailMessage.Bind(exchange, msgItem.Id);
          FileAttachment fa = msgInfo.Attachments[0] asFileAttachment;
          if (fileExtensions.Any(ext => ext.Contains(fa.Name.Substring(fa.Name.Length - 3))))                            
            {    
            fa.Load();
            ResponseMessage responseMessage = msgInfo.CreateForward();
            responseMessage.BodyPrefix = "messageBody";
            responseMessage.ToRecipients.Add("toAddress");
            responseMessage.Subject = "subject";
            responseMessage.SendAndSaveCopy();
    
            }    
        }
