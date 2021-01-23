    private static Action<XmlSchemaSet, DataSet> GetLoadSchemaMethod()
    {
        var type = (from aN in Assembly.GetExecutingAssembly().GetReferencedAssemblies()
            where aN.FullName.StartsWith("System.Data")
            let t = Assembly.Load(aN).GetType("System.Data.XSDSchema")
            where t != null
            select t).FirstOrDefault();
        var pschema = Expression.Parameter(typeof (XmlSchemaSet));
        var pdataset = Expression.Parameter(typeof (DataSet));
        var exp = Expression.Lambda<Action<XmlSchemaSet, DataSet>>(Expression.Call
            (Expression.New(type.GetConstructor(new Type[] {}), new Expression[] {}),
                type.GetMethod("LoadSchema", new[]
                {
                    typeof (XmlSchemaSet), typeof (DataSet)
                }), new Expression[]
                {
                    pschema, pdataset
                }), new[] {pschema, pdataset});
        return exp.Compile();
    }
