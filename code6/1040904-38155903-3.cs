    public abstract class Rule
    {
        private Dictionary<string, object> rule { get; } = new Dictionary<string, object>();
    
        protected void AddRule(string key, object value)
        {
            if (rule.ContainsKey(key))
            {
                rule.Add(key, value);
            }
            else
            {
                rule[key] = value;
            }
        }
    
        protected IEnumerable<KeyValuePair<string, object>> RegisteredRules
        {
            get
            {
                return rule.AsEnumerable();
            }
        }
    }
    
    public abstract class PropertyRule : Rule
    {
        public MemberInfo PropertyInfo { get; protected set; }
    
        public void Update(JsonProperty contract)
        {
            var props = typeof(JsonProperty).GetProperties();
            foreach (var rule in RegisteredRules)
            {
                var property = props.Where(x => x.Name == rule.Key).FirstOrDefault();
                if (property != null)
                {
                    var value = rule.Value;
                    if (property.PropertyType == value.GetType())
                    {
                        property.SetValue(contract, value);
                    }
                }
            }
        }
    }
    
    public class PropertyRule<TClass, TProp> : PropertyRule
    {
        public const string CONVERTER_KEY = "Converter";
        public const string PROPERTY_NAME_KEY = "PropertyName";
        public const string IGNORED_KEY = "Ignored";
    
        public PropertyRule(Expression<Func<TClass, TProp>> prop)
        {
            PropertyInfo = (prop.Body as System.Linq.Expressions.MemberExpression).Member;
        }
    
        public PropertyRule<TClass, TProp> Converter(JsonConverter converter)
        {
            AddRule(CONVERTER_KEY, converter);
            return this;
        }
    
        public PropertyRule<TClass, TProp> Name(string propertyName)
        {
            AddRule(PROPERTY_NAME_KEY, propertyName);
            return this;
        }
    
        public PropertyRule<TClass, TProp> Ignore()
        {
            AddRule(IGNORED_KEY, true);
            return this;
        }
    }
    
    public interface SerializationSettings
    {
        IEnumerable<Rule> Rules { get; }
    }
    
    public class SerializationSettings<T> : SerializationSettings
    {
        private List<Rule> rules { get; } = new List<Rule>();
    
        public IEnumerable<Rule> Rules { get; private set; }
    
        public SerializationSettings()
        {
            Rules = rules.AsEnumerable();
        }
    
        public PropertyRule<T, TProp> RuleFor<TProp>(Expression<Func<T, TProp>> prop)
        {
            var rule = new PropertyRule<T, TProp>(prop);
            rules.Add(rule);
            return rule;
        }
    }
        
    public class FluentContractResolver : DefaultContractResolver
    {
        static List<SerializationSettings> settings;
    
        public static void SearchAssemblies(params Assembly[] assemblies)
        {
            SearchAssemblies((IEnumerable<Assembly>)assemblies);
        }
    
        public static void SearchAssemblies(IEnumerable<Assembly> assemblies)
        {
            settings = assemblies.SelectMany(x => x.GetTypes()).Where(t => IsSubclassOfRawGeneric(t, typeof(SerializationSettings<>))).Select(t => (SerializationSettings)Activator.CreateInstance(t)).ToList();
        }
    
        //http://stackoverflow.com/questions/457676/check-if-a-class-is-derived-from-a-generic-class
        static bool IsSubclassOfRawGeneric(System.Type toCheck, System.Type generic)
        {
            if (toCheck != generic)
            {
                while (toCheck != null && toCheck != typeof(object))
                {
                    var cur = toCheck.IsGenericType ? toCheck.GetGenericTypeDefinition() : toCheck;
                    if (generic == cur)
                    {
                        return true;
                    }
                    toCheck = toCheck.BaseType;
                }
            }
            return false;
        }
    
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            var contract = base.CreateProperty(member, memberSerialization);
    
            var rule = settings.Where(x => x.GetType().BaseType.GenericTypeArguments[0] == member.DeclaringType).SelectMany(x => x.Rules.Select(r => r as PropertyRule).Where(r => r != null && r.PropertyInfo.Name == member.Name)).FirstOrDefault();
            if (rule != null)
            {
                rule.Update(contract);
            }
            return contract;
        }
    }
