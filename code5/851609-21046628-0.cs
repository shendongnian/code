    public List<UserProductRating> GetUserProductRatings<TKey>(int userId, IPager pager, Func<UserProductRating, TKey> orderBy)
    {
        var result = _userProductRatingRepo.Table.Where(a => a.UserId == userId)
            .Join(_productRepo.Table, outer => outer.ProductId, inner => inner.ProductId,
            (outer, inner) => new { UserProductRating = outer, Product = inner })
            .OrderByDescending(o => orderBy(o.UserProductRating)) // <-- pass the joined property to the order function 
            .Skip(pager.Skip).Take(pager.PageSize)
            .Select(a => new
            {
                a.UserProductRating.UserId,
                a.UserProductRating.ProductId,
                a.UserProductRating.VoteCount,
                a.UserProductRating.TotalViews,
                a.UserProductRating.Rating,
                a.Product.Name
            }).ToList();
    }
