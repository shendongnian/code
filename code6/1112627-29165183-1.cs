    [ResponseType(typeof(List<Question>))]
    public async Task<IHttpActionResult> GetQuestion(int questionnaireId)
    {
        var questions = from q in db.Questions
        where q.QuestionnaireId == questionnaireId
        select new Question()
        {
                Id = q.Id,
                ImageLink = q.ImageLink,
                QuestionnaireId = q.QuestionnaireId,
                Text = q.Text
        };
        return this.Ok(questions);
    }
