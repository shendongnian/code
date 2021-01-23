    public abstract class ConfigurationList<TConfigurationObject, TPropertyEnum>
    {
        public QuerySettings<TConfigurationObject, TPropertyEnum> CreateQuerySettings()
        {
            return new QuerySettings<TConfigurationObject, TPropertyEnum>();
        }
    }
    
    public class TConfigurationObjectList : ConfigurationList<BaseScriptConfiguration, BaseScriptConfiguration.Property>
    {
    
    }
    
    public class EditableConfigurationList<T, T1> : TConfigurationObjectList
    {
        protected EditableConfigurationList(ConfigurationManager configurationManager, object baseScript)
        {
            throw new NotImplementedException();
        }
    }
    
    public class BaseScriptConfigurationList : EditableConfigurationList<BaseScriptConfiguration, BaseScriptConfiguration.Property>
    {
        public BaseScriptConfigurationList(ConfigurationManager configurationManager)
            : base(configurationManager, InternalAdminObjectType.BaseScript)
        {
    
        }
    
        public new QuerySettings<BaseScriptConfiguration, BaseScriptConfiguration.Property> CreateQuerySettings()
        {
            return new HierarchicalQuerySettings<BaseScriptConfiguration, BaseScriptConfiguration.Property, BaseScriptQueryChildrenSettings>();
        }
    }
    
    public class QuerySettings<T, T1>
    {
    }
    
    public class HierarchicalQuerySettings<T, T1, T2> : QuerySettings<BaseScriptConfiguration, BaseScriptConfiguration.Property>
    {
    }
    
    public class BaseScriptQueryChildrenSettings
    {
    }
    
    public class BaseScriptPageConfiguration
    {
        public class Property
        {
        }
    }
    
    public class InternalAdminObjectType
    {
        public static object BaseScript { get; set; }
    }
    
    public class ConfigurationManager
    {
    }
    
    public class BaseScriptConfiguration
    {
        public class Property
        {
        }
    }
