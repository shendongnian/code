    public IEnumerable<Comment> GetComments(
        IEnumerable<ContentItem> commentContentItems)
    {
        return commentContentItems.Where(x=>!x.IsDeleted).Select(x=>new new Comment
                {
                    CommentCreatedByName = x.InitiatorName,
                    CommentCreatedByID = x.CreatedByID,
                    ContentItemID = x.ContentItemID,
                    CommentDate = x.CreatedDate
                });
    }
