    private Dictionary<string, string> GetCatgoryScoresByBrandId(string brandId)
        {
            
            var scores = from s in db.CategoryScoresModel
                         where s.BrandId == brandId
                         select new CategoryScoresDTO()
                         {
                             CategoryId = s.CategoryId,
                             TraqCategoryScore = s.TraqCategoryScore,
                             
                         };
            Dictionary<string, string> categoryScores = new Dictionary<string, string>();
            categoryScores = scores.ToDictionary(x => x.CategoryId, x => x.TraqCategoryScore);
            return categoryScores;
        }
