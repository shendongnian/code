    select new ArticleDTO() {    
        ArticleID=p.ArticleID,
        Title = p.Title,
        Subheading = p.Subheading,
        DatePublished = p.DatePublished,
        Body = p.Body,
        Tags = Tags.Select(t => new TagDTO {
                                             Name = t.Name
                                           })
        };
