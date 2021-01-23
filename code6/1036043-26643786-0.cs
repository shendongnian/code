    public async Task<List<Review>> GetTitleReviews(int titleID)
    {
        using (var context = new exampleEntities())
        {
            return await Task.Run(() => context.Reviews.Where(x => x.Title_Id == titleID).ToList());
        }
    }
