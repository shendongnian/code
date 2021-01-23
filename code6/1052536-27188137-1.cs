    return (db.Stories.Include(x => x.Comments)).AsEnumerable().Select(p => 
               new StoryDTO()
               {
                   StoryId = p.StoryId,
                   LastComment = p.LastComment,
                   NumberOfComments = p.Comments.Count
    
               };
