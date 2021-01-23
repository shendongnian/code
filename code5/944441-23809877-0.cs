    public class SentItemsArchiveQueue 
    {
      Items _items;
    
      public void EnQueue(MailItem mail)
        {
          _items = mail.SaveSentMessageFolder.Items;
          _items.ItemAdd += new ItemsEvents_ItemAddEventHandler(EMailFoundInSentItems);
    
          this.Queue.Add(mail.ConversationIndex);
          Trace.TraceInformation("Queue ConversationIndex is {0}", mail.ConversationIndex);
        }
