    [Serializable]
    public QuestionCollection
    {
      public QuestionCollection()
      {
        this.Questions = new List<Question>();
      }
      public List<Question> Questions { get; set; }
    }
