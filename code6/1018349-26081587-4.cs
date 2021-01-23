    var choices = db.yaf_Choice
                        .Where(c => c.PollID == model.ID)
                        .Select(c => new
                        {
                            c.Choice,
                            c.Votes,
                        })
                        .ToList();
    foreach (var ch in choices)
    {
        model.Choices.Add(new KeyValuePair<string, int>(ch.Choice, ch.Votes));
    }
