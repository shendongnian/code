    public static IList<QuizGroups> GetGroups(string sectorId) 
    {
        var Quizes = _QuizDataSource.AllQuizGroups
            .Where(x => x.Subtitle == sectorId)
            .Take(5)
            .ToList();
        return Quizes;
    }
