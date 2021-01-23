    public void FindVenue()
    {
        // find venue in db
        // If not in db - find from 3rd party api
        // If from 3rd party api check if city exits in db
        // If city does not exist...
        CreateCity(context);
        // If venue does not exist create a new venue record in db
        context.SaveChanges();
    }
    public void CreateCity(YourContext context)
    {
        // Create city, don't save changes
    }
    public void CreateAndSaveCity(YourContext context)
    {
        CreateCity();
        context.SaveChanges();
    }
