    public List<Answer> CleanAnswers {
        get {
            return Answers.Select(a => a.CleanText()).ToList();
        }
    }
