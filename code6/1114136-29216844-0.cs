    context.Questions
    .GroupJoin
    (
        context.Answers,
        x=>x.Id, // this is the pk on Questions
        x=>x.QuestionId //this is the fk on Answers
        (q,a)=>new Question
        {
            q.QuestionUId,
            q.Text,
            Answers = a.Select(an=>new Answer{an.AnswerId,an.AnswerText})
        }    
    )
