    public static IList<QuizGroups> GetGroups(string sectorId) 
    {
        var Quizes = _QuizDataSource.AllQuizGroups
            .Where(x => x.Subtitle == sectorId)
            .OrderBy(x => CreatedAt)
            .Take(5)
            .ToList();
        return Quizes;
    }
