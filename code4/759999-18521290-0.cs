    public class CustomMappingSource : MappingSource
    {
        private AttributeMappingSource mapping = new AttributeMappingSource();
        protected override MetaModel CreateModel(Type dataContextType)
        {
            return new CustomMetaModel(mapping.GetModel(dataContextType));
        }
    }
