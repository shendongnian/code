    public void Update(Question q)
    {
      using(var context = new MyDbContext())
      {
        var entity = context.Question.Find(q.Id);
        entity.Content = q.Content;
        foreach(var oldAnswer in entity.Answer)
        { 
          context.Answers.Remove(oldAnswer);
        }
        entity.Answer.Clear(); 
        foreach(var newAnswer in q.Answer)
        {
          entity.Answer.Add(newAnswer);
        }
        context.SaveChanges();
      } 
    }
