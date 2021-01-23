    class CompositeKeyConvention : ICompositeIdentityConvention
    {
        public void Apply(ICompositeIdentityInstance instance)
        {
            var columninspector = instance.KeyManyToOnes.First(k => k.Name == "Key").Columns.First();
            var columnmapping = (ColumnMapping)columninspector.GetType().GetField("mapping", BindingFlags.GetField | BindingFlags.Instance | BindingFlags.NonPublic).GetValue(columninspector);
            columnmapping.Name = "IdColName";
        }
    }
