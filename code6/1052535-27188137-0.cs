    return (db.Stories.Include(x => x.Comments)).ToList().Select(p => 
               new StoryDTO()
               {
                   StoryId = p.StoryId,
                   LastComment = p.LastComment,
                   NumberOfComments = p.Comments.Count
    
               };
