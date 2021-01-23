    public BlogPostGetByUrlSlugDto GetByUrlSlug(string urlSlug)
    {
        var blogPostQuery = _blogPostRepository.Query;
        return blogPostQuery
                    .Where(b => b.UrlSlug.Equals(urlSlug))
                    .ToList()
                    .Select(bp => new BlogPostGetByUrlSlugDto 
                    { 
                        Id = bp.Id, 
                        Title = bp.Title, 
                        Category = bp.BlogCategory == null ? string.Empty : bp.BlogCategory.Name, 
                        Color = bp.BlogCategory == null ? string.Empty : bp.BlogCategory.Color, 
                        UrlSlug = bp.UrlSlug, 
                        Description = bp.Description,
                        Tags = bp.BlogTags.Select(t => new BlogTagGetByPostIdDto 
                                            { 
                                                Name = t.Name, 
                                                UrlSlug = t.UrlSlug
                                            })
                                            .ToList() 
                    })
                    .Single();
    }
