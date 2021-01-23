    public void InsertOrUpdate(Boat boat) 
    { 
        using (var context = new BoatContext()) 
        { 
            context.Entry(boat).State = boat.id == 0 ? 
                                       EntityState.Added : 
                                       EntityState.Modified; 
     
            context.SaveChanges(); 
        } 
    }
