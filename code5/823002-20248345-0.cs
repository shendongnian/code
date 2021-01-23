    var ds = GetData(...);
    if(ds.Any()){
        var m = typeof(Queryable).GetMethod("Cast",BindingFlags.Static | BindingFlags.Public, null,new[] { typeof(IQueryable<Base>) }, null).MakeGenericMethod(ds.First().GetType());
        var r = m.Invoke(ds, new[] {ds});
    }
