    public IEnumerable<MergeObj> QueryJoin()
        {
            List<TableObj1> t1 = conn.Table<TableObj1>().ToList();
            List<TableObj2> t2 = conn.Table<TableObj2>().ToList();
            return t1.Join(t2, outer => outer.Id, 
                               inner => inner.Id, 
                               (outer, inner) => new MergeObj { Obj1 = outer, Obj2 = inner });
        }
