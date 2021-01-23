    List<T> GetKeyNames<T>(object whatever, T entity){
       ....
    }
    // Then you call it like this
    Data.Helpers.EntityKeyHelper.Instance.GetKeyNames(this, dbEntry.Entity);
