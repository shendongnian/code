    var zipped = new ClientAnswers()
                 {
                    Answers = (from rows in afd.Answers
                              select new AnswerDetail()
                              {
                                  AnswerId = rows.AnswerId,
                                  Correct = rows.Correct,
                                  Response = afd.Answers.First(r => r.AnswerId == rows.AnswerId).Response,
                                  Text = rows.Text
                              }).ToList()
                };
