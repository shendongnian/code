    public QuestionDetail GetQuestionDetail(int questionId)
    {
        Question question = _questionsRepository.GetById(questionId).ToList();
        QuestionDetail questionDetail = new QuestionDetail()
        {
            QuestionId = questionId,
            Text = question.Text.FormatCode()
        };
        return questionDetail;
    }
