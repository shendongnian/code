    var model = db.Posts
            .Include( "UserProfile" )
            .OrderByDescending(d => d.PostDate)
            .Select(p => new PostViewModel
            {
                Id = p.Id,
                Title = p.Title,
                Link = p.Link,
                Description = p.Description,
                Username = p.UserProfile.UserName
            }).ToList();
