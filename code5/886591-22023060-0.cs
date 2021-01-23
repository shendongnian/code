    var responses = new Responses();
        responses.Questions = form.Questions.Select(
                        q => new Models.Question()
                        {
                            QuestionId = Convert.ToInt32(q.Id),
                            Value = q.SingleAnswer,
                            Options = q.Options.Select( o =>
                                new Option // <----FAILING HERE!!!!!!!!!!!!
                                {
                                    OptionId = 1,
                                    Value = "test"
                                }
                                ))
    
                        })
                    ).ToList();
