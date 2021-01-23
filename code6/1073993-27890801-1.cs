    public Profile Add()
        {
            Profile item = db.Profiles.Create();
            item.Name = "Bob";
    
            db.Profiles.Add(item);
            db.SaveChanges();
            return item;
        } 
