    public static IQueryable<Comment> WhereIsUnread(this IQueryable<Comment> src, int userId)
    {
        return src.Where(
            c =>
            !c.Deleted && c.CreatedByActorID != actorId
            && (viewed == null || c.ItemCreatedDate > c.Alert.LastView.LastViewedDate));
    }
    
    ...
    
    return (from a in alerts
            select
            new UnreadComments
                {
                   TotalNumberOfUnreadComments = 
                        a.Comments.WhereIsUnRead(actorId).Count()
                })
