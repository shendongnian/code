    public void GenericSetItemIsActive<T>(int id) where T : class
    {
        using (var db = new HotSpottingContext())
        {
            Expression<Func<T, bool>> whereFunction = m => m.As<dynamic>().ID == id;
    
            var selectedItem = db.Set<T>().FirstOrDefault(whereFunction);
    
            if (selectedItem != null)
            {
                dynamic dynamicItem = selectedItem;
                dynamicItem.IsActive = !dynamicItem.IsActive;
    
                db.Entry(dynamicItem).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
    }
