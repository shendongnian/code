    /// <summary>
    /// Gets lists of numQuestions length of all combinations 
    /// of questions whose difficulties add up to sumDifficulty
    /// </summary>
    /// <param name="questions">The list of questions to search</param>
    /// <param name="numQuestions">The number of questions required</param>
    /// <param name="sumDifficulty">The amount that the difficulties should sum to</param>
    /// <returns></returns>
    public static List<List<Question>> GetQuestions(List<Question> questions,
        int numQuestions, int sumDifficulty)
    {
        if (questions == null) throw new ArgumentNullException("questions");
        var results = new List<List<Question>>();
        // Fail fast argument validation
        if (numQuestions < 1 || 
            numQuestions > questions.Count ||
            sumDifficulty < numQuestions * Question.MinDifficulty ||
            sumDifficulty > numQuestions * Question.MaxDifficulty)
        {
            return results;
        }
        var candidateQuestions =
            questions.Where(q => q.Difficulty <= sumDifficulty - numQuestions + 1)
                .ToList();
        if (!candidateQuestions.Any())
        {
            return results;
        }
        GetSumsRecursively(candidateQuestions, sumDifficulty, new List<Question>(), 
            numQuestions, results);
        return results;
    }
