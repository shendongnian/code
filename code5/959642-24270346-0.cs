    class Rating {
        public Int32 Rating { get; set; }
        public Int32 TotalCount { get; set; }
    }
    ...
    .Select(group => new Rating { Rating = group.Key, TotalCount = group.Count() });
    ...
    foreach(Rating rating in ViewBad.Ratings) {
        @rating.TotalCount
    }
