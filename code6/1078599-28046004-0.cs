    public class EntityOverride:IAutoMappingOverride<Entity>
        {
            public void Override(AutoMapping<RealEstateFile> mapping)
            {
                mapping.HasMany(x => x.Usage).Element("Usages").AsBag();
            }
        }
