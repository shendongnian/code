    public class ObjectWrapper
    {
        private readonly object wrappedInstance;
        private readonly ReadOnlyCollection<PropertyWrapper> propertyWrappers;
    
        public ObjectWrapper(object instance)
        {
            Collection<PropertyWrapper> collection = new Collection<PropertyWrapper>();
            Type instanceType;
    
            wrappedInstance = instance;
            instanceType = instance.GetType();
    
            foreach (PropertyInfo propertyInfo in instanceType.GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance))
            {
                collection.Add(new PropertyWrapper(instance, propertyInfo));
            }
    
            propertyWrappers = new ReadOnlyCollection<PropertyWrapper>(collection);
        }
    
        public ReadOnlyCollection<PropertyWrapper> PropertyWrappers
        {
            get
            {
                return propertyWrappers;
            }
        }
    
        public object Instance { get { return wrappedInstance; } }
    }
    
    public class PropertyWrapper
    {
        private readonly object instance;
        private readonly PropertyInfo propertyInfo;
    
        public PropertyWrapper(object instance, PropertyInfo propertyInfo)
        {
            this.instance = instance;
            this.propertyInfo = propertyInfo;
        }
    
        public string Label
        {
            get
            {
                return propertyInfo.Name;
            }
        }
    
        public Type PropertyType
        {
            get
            {
                return propertyInfo.PropertyType;
            }
        }
    
        public object Value
        {
            get
            {
                return propertyInfo.GetValue(instance, null);
            }
            set
            {
                propertyInfo.SetValue(instance, value, null);
            }
        }
    }
