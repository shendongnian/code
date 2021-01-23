    using (ClearWhiteDBEntities cwContext = new ClearWhiteDBEntities())
    {
        var qlstfld = from lstflds in cwContext.tblListFields
                                  where lstflds.listId == theLongSrc
                                  select lstflds;
    
        foreach (var item in qlstfld)
        {
            cwContext.ObjectStateManager.ChangeObjectState(item, System.Data.EntityState.Added);
            item.Id = 0;
            item.listId = theLongDes; //this field must be change in paste
        }
        cwContext.SaveChanges();
    }
