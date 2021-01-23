    TRDCommunityViewModel community = await _db.Communities
      .Select(c => new TRDCommunityViewModel
       {
        Id = c.Id,
        CommunityId = c.Guid,
        Created = c.Created,
        Description = c.Description,
        IAmAdmin = (c.Admins.FirstOrDefault(k => k.Id == userId) != null),
        Members = c.Members.Select(a => new TRDIdenityViewModel()
          {
            // do your assignments here...
          }),
        Posts = c.Posts.Select(a => new TRDIdenityViewModel()
          {
            //do your assignments here...
          })
            // and so on
        })
       .FirstOrDefaultAsync(k => k.Id == Id);
