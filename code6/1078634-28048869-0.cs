    public Feed GetFeedDapper(int feedId)
    {
        Feed feed = null;
        
        var multiPredicate = new GetMultiplePredicate();
        multiPredicate.Add<Feed>(Predicates.Field<Feed>(x => x.FeedId, Operator.Eq, feedId));
        multiPredicate.Add<InboundProperties>(Predicates.Field<InboundProperties>(x => x.FeedId, Operator.Eq, feedId));
        multiPredicate.Add<OutboundProperties>(Predicates.Field<OutboundProperties>(x => x.FeedId, Operator.Eq, feedId));
        multiPredicate.Add<FeedFilterParameter>(Predicates.Field<FeedFilterParameter>(x => x.FeedId, Operator.Eq, feedId));
        multiPredicate.Add<TeamFeed>(Predicates.Field<TeamFeed>(x => x.FeedId, Operator.Eq, feedId));
    
        var result = DbConnection.GetMultiple(multiPredicate);
    
        feed = result.Read<Feed>().Single();
        feed.InboundProperties = result.Read<InboundProperties>().Single();
        feed.OutboundProperties = result.Read<OutboundProperties>().Single();
        feed.Parameters = result.Read<FeedFilterParameter>().ToList();
        feed.TeamFeeds = result.Read<TeamFeed>().ToList();
        
        return feed;
    }
