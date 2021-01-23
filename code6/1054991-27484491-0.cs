    public List<Model> CallFoo(ISession session, DateRange range)
    {
        return session.CreateSqlQuery("call sproc")
            .SetParameter(...)
            .SetResultTransformer(new ModelResultTransformer())
            .List<Model>();
    }
    class ModelResultTransformer : NHibernate.Transform.IResultTransformer
    {
        public IList TransformList(IList collection)
        {
            return collection;
        }
        public object TransformTuple(object[] tuple, string[] aliases)
        {
            var model = new Model();
            for (int i = 0; i < aliases.Length; i++)
            {
                var columnName = aliases[i];
                var value = tuple[i];
                switch (columnName)
                {
                    case "column1":
                        model.Prop1 = (string)value;
                        break;
                    case "column2":
                        model.Prop2 = (int)value;
                        break;
                    case "column3":
                        model.Prop1 = (int)value;
                        break;
                }
            }
        }
    }
