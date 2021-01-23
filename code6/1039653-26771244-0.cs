    [Output("List of Contacts")]
    [ReferenceTarget("list")]
    public OutArgument<EntityReference> MarketingListRef { get; set; }
    // code to create the marketing list and add the contacts
    Guid marketingListId;
    
    // set the OutArgument
    EntityReference marketingListRef = new EntityReference("list",marketingListId);
    MarketingListRef.Set(executionContext, marketingListRef);
