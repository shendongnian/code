    var radioList = new [] {radiobuttonlist1, radiobuttonlist2, ...};
    for(int i = 0; i < quiz.Items.Length; i++)
    {
        var quizId = quiz.Items[i].questionId;
        radioList[i].InnerText = quiz.Items[i].QuestionText;
        radioList[i].Items.AddRange(quiz.Items[i]
                                        .AnswerChoice
                                        .Select(q => => new ListItem(q.Value, q.answerId))
                                        .ToArray()
                                    );
    }
