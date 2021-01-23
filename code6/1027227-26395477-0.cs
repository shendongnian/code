    QuestionModel questionFromDb;
    QuestionModel questionFromPost;
    QuestionModelChoice[] deletedChoices = questionFromDb.Choices.Where(c => !questionFromPost.Choices.Any(c2 => c2.Id == c.Id));
    
    using (var db = new DbContext())
    {
        db.Entry(questionFromPost).State = questionFromPost.Id == 0 ? EntityState.Added : EntityState.Modified;
    
        foreach(var choice in questionFromPost.Choices)
        {
            db.Entry(choice).State = choice.Id == 0 ? EntityState.Added : EntityState.Modified;
        }
        foreach(var deletedChoice in deletedChoices)
        {
            db.Entry(deletedChoice).State = EntityState.Deleted;
        }
    
        db.SaveChanges();
    }
