       var linqAnswers = from question in Questions
                                group question by question.Answer into grpAnswer
                                select new
                                {
                                    answer = grpAnswer.Key,
                                    count = grpAnswer.Count(),
                                    data = ProcessAnswerFrequencyData(Questions, grpAnswer)
                                };
     protected IEnumerable<QuestionAnswerChartPoint> ProcessAnswerFrequencyData(IEnumerable<Question> list, IGrouping<string, Question> grp)
    {
        //Do more processing on the group and return a reporting list.
    }
