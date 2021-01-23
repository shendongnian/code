    Conversation conversation = null;
    ConversationMessage message = null;
    
    // the subselect of a max
    var subQuery = QueryOver.Of<ConversationMessage>(() => message)
        .Where(() => message.Conversation.ID == conversation.ID)
        .Select(Projections.Max("CreatedDate"));
    
    // the alias of the Conversation to be injected into subquery
    var query = session.QueryOver<Conversation>(() => conversation);
    
    // a select and group by (distinct) clause
    query.SelectList(l => l
        .SelectGroup(s => conversation.ID)
        .Select(Projections.SubQuery(subQuery))
        );
    
    // Order by the max Created date (asc)
    var list = query
        .OrderBy(Projections.SubQuery(subQuery))
            .Asc
        .List<object[]>()
        ;
