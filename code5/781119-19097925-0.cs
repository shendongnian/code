    var query = //your original query goes here
    
    var finalQuery = query.AsEnumerable()
        .Select((answer, index) => new
            {
                answer.SubmissionId,
                answer.Answer,
                Code = index,
            });
