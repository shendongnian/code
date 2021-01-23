    var result = _blogPostRepository.Query
    			  				   .Where(b => b.UrlSlug.Equals(urlSlug))
    							   .Include(b => b.Tags) 
    							   .Select(bp => new BlogPostGetByUrlSlugDto 
    								{ 
    									Id = bp.Id, 
    									Title = bp.Title, 
    									Category = bp.BlogCategory.Name, 
    									Color = bp.BlogCategory.Color, 
    									UrlSlug = bp.UrlSlug, 
    									Description = bp.Description,
    									Tags = bp.Tags.Select(t => new BlogTagGetByPostIdDto 
    														{ 
    															Name = t.Name, 
    															UrlSlug = t.UrlSlug
    														})
    								})
    								.FirstOrDefault();
    								
    return result;
