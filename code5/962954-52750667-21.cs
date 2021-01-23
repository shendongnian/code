    private SelectListItem[] _QuestionsList;
    public SelectListItem[] GetQuestionsList()
    {
        if (_QuestionsList == null)
        {
            var questions = PasswordResetQuestionUserAnswers.Select(a => new SelectListItem()
            {
                Text = a.Answer, //? I didn't see a "PasswordResetQuestionText" call in your example, so...
                Value = a.PasswordResetQuestionId.ToString()
            }).ToList();
            questions.Insert(1, new SelectListItem() { Value = "1", Text = "Mother's Maiden Name" });
            questions.Insert(2, new SelectListItem() { Value = "2", Text = "Elementary school attended" });
            _QuestionsList = questions.ToArray();
        }
        // Have to create new instances via projection
        // to avoid ModelBinding updates to affect this
        // globally
        return _QuestionsList
             .Select(d => new SelectListItem()
        {
             Value = d.Value,
             Text = d.Text
        })
        .ToArray();
    }
