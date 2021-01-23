    public ActionResult SomeMethod(FormCollection coll)
    {
        var sortingColumnNumber = Convert.ToInt32(coll["iSortCol_0"]);
        var sortingColumnName = coll[string.Format("mDataProp_{0}", sortingColumnNumber)]; 
        var propertyInfo = typeof(SomeObject).GetProperty(sortingColumnName);
        
        //..get List<SomeObject> sortedObjects
        sortedObjects = sortedObjects.OrderBy(x => propertyInfo.GetValue(x, null)).ToList();
        //...
    }
