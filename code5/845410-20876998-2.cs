    var drama = new Drama { Id = id, ClassName = "Dummy" };
    using (var ctx = new DataContext()) {
        ctx.Dramas.Attach(drama);
        drama.Status = state;
        ctx.SaveChanges();
    }
