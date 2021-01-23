    var zipped = new ClientAnswers()
                 {
                    QuestionId = yourQuestionId, 
                    Answers = (from rows in afd.Answers
                              select new AnswerDetail()
                              {
                                  AnswerId = rows.AnswerId,
                                  Correct = rows.Correct,
                                  Response = rfc.Answers.First(r => r.AnswerId == rows.AnswerId).Response,
                                  Text = rows.Text
                              }).ToList()
                };
