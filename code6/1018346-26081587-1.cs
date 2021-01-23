    var poll = db.yaf_Poll
                .Where(p => p.PollID == model.ID)
                .Select(p => new
                {
                    p.Question,
                    p.AllowMultipleChoices,
                    p.Closes
                })
                .First();
    model.Question = poll.Question;
    model.IsMultipleChocie = poll.AllowMultipleChoices;
    model.ExperationDate = poll.Closes;
