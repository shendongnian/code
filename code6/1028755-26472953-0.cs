    public IEnumerable<MergeObj> QueryJoin() {
        return (
            from obj1 in conn.Table<TableObj1>()
            join obj2 in conn.Table<TableObj2>()
            on obj1.Id
            equals obj2.Id
            select new {obj1, obj2}
        ).AsEnumerable()
         .Select(o => new MergeObj{Obj1 = o.obj1, Obj2 = o.obj2}) ;
    }
