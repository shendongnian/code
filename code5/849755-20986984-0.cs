    public static void GetEmail(ExchangeService service, ItemId ItemId)
    {
        PropertySet propSet = new PropertySet(BasePropertySet.IdOnly, ItemSchema.TextBody, EmailMessageSchema.Body);
        EmailMessage message = EmailMessage.Bind(service, ItemId, propSet);
    }
