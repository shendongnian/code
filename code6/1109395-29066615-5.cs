    public override int SaveChanges()
    {
        Bookings.Local
                .Where(r => r.ContactId == null)
                .ToList()
                .ForEach(r => Bookings.Remove(r));
 
        return base.SaveChanges();
     }
