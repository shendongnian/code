    return answers.Select(survey => survey.Answers.Join(key.Answers,
                                                        a => a.Question.Id,
                                                        b => b.Question.Id,
                                                        (a, b) => new {
                                                                          answer = a,
                                                                          expected = b
                                                                      }))
                  .Where(c => c.All(x => x.expected.SelectedAnswers
                                                   .GroupJoin(x.answer.SelectedAnswers,
                                                              a => a.Id,
                                                              b => b.Id,
                                                              (a, b) => b.Any())));
