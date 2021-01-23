    using System.Data.Entity;
    public async Task<List<Review>> GetTitleReviews(int titleID)
    {
        using (var context = new exampleEntities())
        {
            return await context.Reviews.Where(x => x.Title_Id == titleID).ToListAsync();        
        }
    }
