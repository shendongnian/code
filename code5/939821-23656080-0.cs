    quizId1 = quiz.Items[0].questionId;
    radiobuttonlist1.InnerText = quiz.Items[0].QuestionText;
    radiobuttonlist1.Items.AddRange(quiz.Items[0]
                                        .AnswerChoice
                                        .Select(q => => new ListItem(q.Value, q.answerId))
                                        .ToArray()
                                   );
