    private bool _collectionsPopulating = false;
    private bool _CollectionsPopulated = false;
    public ViewManager Views 
    { 
         get 
         { 
             if (_collectionsPopulating) return null;
             PopulateCollections(); 
             return _collectionsPopulat_Views;
         }
    }
    void PopulateCollections()
    {
        if (_CollectionsPopulated) return;
        _collectionsPopulating = true;
        foreach (ClassTable item in ClassessTables)
        {
            item.ReflectMe();
        }
        _CollectionsPopulated = true;
        _collectionsPopulating = false;
    }
