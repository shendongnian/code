    var responses = new Responses();
        responses.Questions = form.Questions.Select(
                    q => new Models.Question()
                    {
                        QuestionId = Convert.ToInt32(q.Id),
                        Value = q.SingleAnswer,
                        Options = q.Options.Select(o =>
                            new Option
                            {
                                OptionId = (int) o.Id,
                                Value = o.Value
                            }).ToList()
                    }).ToList();
