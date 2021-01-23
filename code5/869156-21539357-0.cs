    public class MyCrazyType : SitecoreFieldTypeMapper
    {
        public override object GetFieldValue(string fieldValue, Mapper.Sc.Configuration.SitecoreFieldConfiguration config, SitecoreDataMappingContext context)
        {
            using (new VersionCountDisabler())
            {
                return base.GetFieldValue(fieldValue, config, context);
            }
        }
        public override bool CanHandle(Mapper.Configuration.AbstractPropertyConfiguration configuration, Context context)
        {
            //this will mean this handle only works for this type
            return configuration.PropertyInfo.PropertyType == typeof (ServiceMapping);
        }
    }
