    set 
    {
        var cc = context.CustomerCategory.Where(c => c.Type == 1).FirstOrDefault();
        if (cc!=null)
        {
            cc.Category =  value;
            //or cc.CategoryId = value.Id; if you have foreign keys exposed
            //context.SaveChanges(); if you need changes saved in the database immediately.
        }
    }
