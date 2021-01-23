    using (var ctx = new DataContext()) {
      drama = ctx.Dramas.Where(O => O.Id = id);
      drama.Status = state;
      ctx.Dramas.Attach(drama);
      ctx.SaveChanges();
