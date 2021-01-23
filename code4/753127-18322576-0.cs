    public void UpdateCategory(Models.Category catData)
    {
        if (catData == null) return;
        using (var cntx = new DataContext())
        {
            //IN THE LINE BELOW A CONNECTION IS DEFINITELY OPENED BUT IS IT IMMEDIATELY CLOSE? => YES!
            var cat = cntx.Set<Category>().FirstOrDefault(c => c.CategoryId == catData.CategoryId);
            if (cat == null) return;
            if (!cat.LastChanged.Matches(catData.LastChanged))
                throw new ConcurrencyException(cat.GetType().ToString());
            cat.CategoryName = catData.CategoryName;
            cntx.DbContext.Entry<Category>(cat).State = System.Data.EntityState.Modified;
            //AFTER THE NEXT LINE DO I HAVE 2 CONNECTIONS OPENED? NO
            cntx.SaveChanges();
            catData.LastChanged = cat.LastChanged;
        }
    }
