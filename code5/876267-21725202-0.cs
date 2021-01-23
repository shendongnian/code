    public static IQueryable<Comment> WhereIsUnread(this IQueryable<Comment> src, int userId)
    {
        return src.Where(
            c =>
            !c.Deleted && c.CreatedByActorID != actorId
            && (viewed == null || c.ItemCreatedDate > c.Alert.LastView.LastViewedDate));
    }
    
    ...
    
    // Throwing "Argument type 'System.Linq.Expression<X,bool>' is not assignable 
    // to parameter type 'System.Func<X,bool>'"
    return (from a in alerts
            select
            new UnreadComments
                {
                   TotalNumberOfUnreadComments = 
                        a.Comments.WhereIsUnRead(actorId).Count()
                })
