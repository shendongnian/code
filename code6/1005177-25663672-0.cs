    private static Answer CreateAnswer (
        int id, string answer, bool isCorrect, int questionId)
    {    
        var answer = new Answer
        {
            Id = id,
            Answer = answer,
            IsCorrect = isCorrect,
            questionId = questionId
        };
        return answer;
    }
