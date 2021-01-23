    public int MyCollectionCount
    {
        get { return Model.MyCollection != null ? Model.MyCollection.Count : 0 ; }
        set { if    (Model.MyCollection != null)  
                     Model.MyCollection.Count = value ; /* ¬_¬ */ }
    }
