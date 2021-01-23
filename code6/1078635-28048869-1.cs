    public class FeedMapper : ClassMapper<Feed>
    {
        public FeedMapper()
        {
            base.Table("Feeds");
            Map(f => f.FeedId).Key(KeyType.Identity);
    
            Map(f => f.Owner).Ignore();
            Map(f => f.TeamFeeds).Ignore();
            Map(f => f.FeedDirection).Ignore();
            Map(f => f.InboundProperties).Ignore();
            Map(f => f.Parameters).Ignore();
            Map(f => f.OutboundProperties).Ignore();
            Map(f => f.RelatedTeams).Ignore();
    
            AutoMap();
        }
    }
    public class InboundPropertiesMapper : ClassMapper<InboundProperties>
    {
        public InboundPropertiesMapper()
        {
            base.Table("Feeds");
            Map(f => f.FeedId).Key(KeyType.Identity);
            
            Map(f => f.Channel).Ignore();
            Map(f => f.FeedScope).Ignore();
    
            Map(f => f.ChannelInt).Column("InboundProperties_ChannelInt");
            Map(f => f.ExternalAPICounts).Column("InboundProperties_ExternalAPICounts");
            Map(f => f.ExternalId).Column("InboundProperties_ExternalId");
            Map(f => f.ExternalLink).Column("InboundProperties_ExternalLink");
            Map(f => f.ExternalName).Column("InboundProperties_ExternalName");
            Map(f => f.ExternalPicture).Column("InboundProperties_ExternalPicture");
            Map(f => f.ExternalRef).Column("InboundProperties_ExternalRef");
            Map(f => f.ExternalRefPrevious).Column("InboundProperties_ExternalRefPrevious");
            Map(f => f.ExternalToken).Column("InboundProperties_ExternalToken");
            Map(f => f.FeedScopeInt).Column("InboundProperties_FeedScopeInt");
            Map(f => f.LastProcessedMessageId).Column("InboundProperties_LastProcessedMessageId");
            Map(f => f.LastProcessedMessageTime).Column("InboundProperties_LastProcessedMessageTime");
            Map(f => f.MessageCountStartDT).Column("InboundProperties_MessageCountStartDT");
            Map(f => f.TenancyId).Column("InboundProperties_TenancyId");
            AutoMap();
        }
    }
    public class OutboundPropertiesMapper : ClassMapper<OutboundProperties>
    {
        public OutboundPropertiesMapper()
        {
            base.Table("Feeds");
            Map(f => f.FeedId).Key(KeyType.Identity);
    
            Map(f => f.Channel).Ignore();
            Map(f => f.FeedType).Ignore();
    
            Map(f => f.OutboundFeedTypeInt).Column("OutboundProperties_OutboundFeedTypeInt");
            Map(f => f.TenancyId).Column("OutboundProperties_TenancyId");
            AutoMap();
        }
    }
