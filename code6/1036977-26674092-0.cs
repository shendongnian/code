    public Equipment Parent 
    {
        get 
        {
            return dataContext.DbSet<Equipment>().SingleOrDefault(e=>e.Id == this.ParentEquipmentId);
        }
    }
    
    public IEnumerable<Equipment> Children 
    {
        get 
        {
            return dataContext.DbSet<Equipment>().Where(e=>e.ParentEquipmentId == this.Id);
        }
    }
