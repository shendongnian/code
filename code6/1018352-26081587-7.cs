    model.Choices = db.yaf_Choice
                        .Where(c => c.PollID == model.ID)
                        .Select(c => new
                        {
                            model.Votes.Key = c.Choice,
                            model.Votes.Value = c.Votes,
                        })
                        .ToList();
