    //...
    List<Guid> listOfGuids = MyMethod(); //No ToList here
    //...
    public List<Guid> MyMethod()
    {
        using (var context = AccesDataRépart.GetNewContextRépart())
        {
            return context.MyTable.ToList();
        }
    }
