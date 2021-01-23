    int questionId = int.Parse(hdnQuestion.Value);
    var answer = new Answer
    {
        Name = tbAnswer.Text,
        AnsweredBy = this.User.Identity.Name,
        AnsweredOn = DateTime.Now
    };
    using(var context = new QnAContext())
    {
        for (var question in context.Questions
                                    .Include(q => q.Answers)
                                    .Where(q => q.Id == questionId))
        {
            question.SpecialtyId = int.Parse(ddlSpecialty.SelectedItem.Value);
            question.Answered = true;
            question.Answers.Add(answer);
        }
        context.SaveChanges();
    }
