    public void deleteFirst<T, U>(Func<T, U> entityCondition) where T: BaseInfo
    {
        var toDelete = Session.QueryOver<T>().Where(x => x.Id != 0)
        	.AndRestrictionOn(entityCondition).IsNotNull.List();
        Session.Delete(toDelete[0]);
    }
