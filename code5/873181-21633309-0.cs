    var questionWithAnswers = Questions
                             .Select(q => new { 
                                        Question = q,
                                        Answer = AnswerDetails
                                       .FirstOrDefault(a => a.Answer.KeyID == q.ID) ?? ""
                              }).ToList();
    var resultSet = String.Join(Environment.NewLine, questionWithAnswers
                                                    .Select(x => String.Format("{0} | {1}",x.Question.Description, x.Answer));
                                                      
