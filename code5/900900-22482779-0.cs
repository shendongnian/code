    ItemView view = new ItemView(10);
    view.PropertySet = new PropertySet(BasePropertySet.IdOnly, EmailMessageSchema.InternetMessageId);
    FindItemsResults<Item> results = service.FindItems(WellKnownFolderName.SentItems, view);
    foreach (Item item in results)
    {
        if (item is EmailMessage)
        {
            EmailMessage msg = item as EmailMessage;
            Console.WriteLine(msg.InternetMessageId);
        }
    }
