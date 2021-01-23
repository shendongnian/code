    public List<item> GetAllItems() 
    {
        using (var context = new DbEntities())
        {
            if (context.items.Count() > 0)
                return context.items.ToList()  //exception generated here
            else 
                return new List<item>();
        }
    }
