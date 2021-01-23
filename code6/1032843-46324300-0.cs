    if (ModelState.IsValid)
    {
        var action = this.db.DbcontextName.Find(int.Parse(id));   
        db.Entry(action).Property("Status").CurrentValue = "YourString/Data";
        db.SaveChanges()          
     }
