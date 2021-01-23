    using (var ctx = new DataContext()) {
        var drama = ctx.Dramas.Single(d => d.Id == id);
        drama.Status = state;
        ctx.SaveChanges();
    }
