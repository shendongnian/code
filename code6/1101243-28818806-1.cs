    private static void GetSumsRecursively(IReadOnlyList<Question> questions, 
        int numQuestions, List<Question> candidates, int numIndexes, 
        ICollection<List<Question>> results)
    {
        int candidateSum = candidates.Sum(x => x.Difficulty);
        if (candidateSum == numQuestions && candidates.Count == numIndexes)
        {               
            results.Add(candidates);
        }
        if (candidateSum >= numQuestions)
            return;
        for (int i = 0; i < questions.Count; i++)
        {
            var remaining = new List<Question>();
            for (int j = i + 1; j < questions.Count; j++)
            {
                remaining.Add(questions[j]);
            }
            var filteredCandidates = new List<Question>(candidates) {questions[i]};
            GetSumsRecursively(remaining, numQuestions, filteredCandidates, 
                numIndexes, results);
        }
    }
