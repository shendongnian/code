    public IQueryable<MyObjectExtended> MyObjectsWithExtraData() {
        var myQuery = from o in _contextProvider.Context.MyObjects
            // big complex query....
            select new MyObjectExtended {
               FieldA = o.FieldA,
               FieldB = o.FieldB,
               //... all fields ...
               ExtraFieldA = x.ResultFromComplexJoinA,
               ExtraFieldB = x.ResultFromComplexJoinB
        };
        return myQuery;
    }
