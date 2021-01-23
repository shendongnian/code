    public class newclass : BaseScriptConfigurationList
    {
        public new HierarchicalQuerySettings<BaseScriptConfiguration, BaseScriptConfiguration.Property> CreateQuerySettings()
        {
            return (HierarchicalQuerySettings<BaseScriptConfiguration, BaseScriptConfiguration.Property>)base.CreateQuerySettings();
        }
    }
