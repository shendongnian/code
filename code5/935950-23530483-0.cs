    var files = (from x in xmlDoc.Elements("User")
                 select
                 new TestCasesViewModel
                      {
                          Name = (string)x.Element("Name") ?? string.Empty,
                          Role = (string)x.Element("Role") ?? string.Empty,
                          QuestionAnswerList = 
                              x.Descendants("QA")
                              .Select(q => new QuestionAnswer
                              {
                                  Question = (string)q.Element("Question"),
                                  Answers = q.Descendants("Answer").Select(a => new AnswerList { Answer = (string)a}).ToList()
                                     
                              }).ToList()
                       }).ToList();
