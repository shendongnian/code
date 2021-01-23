    public void Update(Question q)
    {
      using(var context = new MyDbContext())
      {
        var entity = context.Question.Find(q.Id);
        entity.Content = q.Content;
        context.SaveChanges();
      } 
    }
