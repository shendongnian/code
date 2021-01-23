        public List<MyType> QueryThis(ViewModel vm)
        {
            using (var db = new MyEntities()){
            var parms = GetParms(vm);
            var query = Resources.QueryStrings.MyQuery;
            var stuff = db.Database.SqlQuery<MyType>(query, parms);
            return stuff.ToList();
        }
