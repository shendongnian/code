    private static void GetSumsRecursively(IReadOnlyList<Question> questions, 
        int sumDifficulty, List<Question> candidates, int numQuestions, 
        ICollection<List<Question>> results)
    {
        int candidateSum = candidates.Sum(x => x.Difficulty);
        if (candidateSum == sumDifficulty && candidates.Count == numQuestions)
        {
            results.Add(candidates);
        }
        if (candidateSum >= sumDifficulty)
            return;
        for (int i = 0; i < questions.Count; i++)
        {
            var remaining = new List<Question>();
            for (int j = i + 1; j < questions.Count; j++)
            {
                remaining.Add(questions[j]);
            }
            var filteredCandidates = new List<Question>(candidates) {questions[i]};
            GetSumsRecursively(remaining, sumDifficulty, filteredCandidates, 
                numQuestions, results);
        }
    }
