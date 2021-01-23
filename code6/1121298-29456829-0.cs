    [HttpPost]
    public PartialViewResult IncrementRating(int compareId)
    {
        var comparison = db.Comparisons.SingleOrDefault(o => o.id == comapreId);
        comparison.Rating += 1;
        //Other edit sutff......
        //db.Comparisons.Attach(comparison);
        db.SaveChanges();
        return PartialView("_Voting", comparison);
    }
