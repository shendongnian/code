    public void CreateApple(IApple apple) 
    {
        Apple newApple = new Apple()
        {
            Color = apple.Color,
            Variety = apple.Variety,
            ...
        }
    
        db.Apples.Add(newApple);   
        db.SaveChanges();
    }
