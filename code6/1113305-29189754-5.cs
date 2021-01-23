    public Measurement GetMeasurement(Guid id)
    {
        using (var context = new ApplicationDbContext())
        {
            Measurement model = new Measurement();
            model = context.Measurements
               .Include(x => x.LeftPicture)
               .Include(x => x.TopPicture)
               .Include(x => x.RightPicture)
               .Include(x => x.BottomPicture)
               .FirstOrDefault(j => j.Id == id);
            return model;
        }
    }
