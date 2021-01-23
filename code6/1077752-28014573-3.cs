    public void Update(Question q)
    {
      using(var context = new MyDbContext())
      {
        var entity = context.Question.Find(q.Id);
        entity.Content = q.Content;
    
        foreach(var newAnswer in q.Answer)
        {
          if (entity.Answer.All(a => a.Id != newAnswer.Id)
          {
            entity.Answer.Add(newAnswer);
          }
        }
    
        foreach(var oldAnswer in entity.Answer)
        { 
          if (q.Answer.All(a => a.Id != oldAnswer.Id)
          {
            context.Answers.Remove(oldAnswer);
          }
          else
          {
            var newAnswer = q.Answer.Single(a => a.Id == oldAnswer.Id);
            oldAnswer.Content = newAnswer.Content;
            oldAnswer.IsTrue = newAnswer.IsTrue;
          }
        }
    
        context.SaveChanges();
      } 
    }
