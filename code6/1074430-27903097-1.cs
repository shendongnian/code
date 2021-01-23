    public KazangAccountClassMap()
    {
        ...
        References(x => x.Channel)
           .Column("Channel_ID"); // the Channel reference
        Map(x => x.ChannelId)
           .Column("Channel_ID");      // the int property ChannleId
