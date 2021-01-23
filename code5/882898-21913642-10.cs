    public void RefreshFromDatabase()
    {
        var repository = new MyEntityRepository();
        IEnumerable<MyEntity> myEntities = repository.GetAll();
        MyEntityCollection = new DisplayItemCollectionBase<MyEntity>(myEntities);
    }
       
