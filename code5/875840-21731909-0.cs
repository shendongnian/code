    private static int __lastProcessedIndex = 0;
    private static DbContext _oldContext = null;
    
    public void DoYourMagic(DbContext context)
    {
        if (ReferenceEquals(context, _oldContext) == false)
        {
            _oldContext = context;
            _lastProcessedIndex = 0;
        }
        var objectContext = (context as IObjectContextAdapter).ObjectContext;
        var unchanged = objectContext.ObjectStateManager.GetObjectSateEntires(EntityState.Unchanged).ToArray();
        for (int i = _lastProcessedIndex; i < unchanged.Length; i++)
        {
            //do your magic with unchanged entities...
        }
        context.SaveChanges();
        //Now all entries in objectstatemanager are in state Unchanged so I am setting the index to the Count() - 1, so that my next call of the method "DoYourMagic" starts the for with this index and ignores all the previously attached ones
        _lastProcessedIndex = objectContext.ObjectStateManager.GetObjectSateEntires(EntityState.Unchanged).Count();
    }
