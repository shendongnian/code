    private EmailMessage BindToEmailMessage(ItemId itemId)
    {
        try
        {
            Item item = Item.Bind(this.ExchangeService, itemId);
            if (item is EmailMessage) return item as EmailMessage;
            else return null;
        }
        catch
        {
            return null;
        }
    }
