    public class CustomMetaModel : MetaModel
    {
        private static CustomAttributeMapping mapping = new CustomAttributeMapping();
        private MetaModel model;
        public CustomMetaModel(MetaModel model)
        {
            this.model = model;
        }
        public override Type ContextType
        {
            get { return model.ContextType; }
        }
        public override MappingSource MappingSource
        {
            get { return mapping; }
        }
        public override string DatabaseName
        {
            get { return model.DatabaseName; }
        }
        public override Type ProviderType
        {
            get { return model.ProviderType; }
        }
        public override MetaTable GetTable(Type rowType)
        {
            return new CustomMetaTable(model.GetTable(rowType), model);
        }
        public override IEnumerable<MetaTable> GetTables()
        {
            foreach (var table in model.GetTables())
                yield return new CustomMetaTable(table, model);
        }
        public override MetaFunction GetFunction(System.Reflection.MethodInfo method)
        {
            return model.GetFunction(method);
        }
        public override IEnumerable<MetaFunction> GetFunctions()
        {
            return model.GetFunctions();
        }
        public override MetaType GetMetaType(Type type)
        {
            return model.GetMetaType(type);
        }
    }
