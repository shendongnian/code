    public string QuestionTypeJson { get; set; }
    
    private QuestionType _questionType = new QuestionType();
    public QuestionType QuestionType
    {
        get => string.IsNullOrEmpty(QuestionTypeJson) ? _questionType : JsonConvert.DeserializeObject<QuestionType>(QuestionTypeJson);
        set => _questionType = value;
    }
