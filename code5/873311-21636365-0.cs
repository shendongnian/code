    select new EvaluationResultSet //Here 
        {
            QuestionID = q.QuestionID,
            ID = q.ID,
            QuestionText = q.Description,
            LeaderAnswerText = la.Comment,
            LeaderAnswerRating = (la.AnswerOptionKey == null ? 0 : la.AnswerOptionKey),
            TeacherAnswerText = ta.Comment,
            TeacherAnswerRating = (ta.AnswerOptionKey == null ? 0 : ta.AnswerOptionKey)
        };
