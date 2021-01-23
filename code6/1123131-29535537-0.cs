        [AttributeUsage(AttributeTargets.Property, Inherited = false)]
        public class CalculatedProperty : Attribute
        {
            private string[] _props;
            public CalculatedProperty(params string[] props)
            {
                this._props = props;
            }
            public string[] Properties
            {
                get
                {
                    return _props;
                }
            }
        }
            public class ObservableObject : INotifyPropertyChanged
            {
                //static, because we use reflication only once on initalization per type that inherits ObservableObject
                //the first key is full type name, the second is the computed property name, the array is the names of the properties that the calculated property depends on
                private static Dictionary<string, Dictionary<string, string[]>> calculatedPropertiesOfTypes = new Dictionary<string, Dictionary<string, string[]>>();
    
                //initalize this in the constructor
                private readonly bool hasComputedProperties;
    
                //the constructor checks if the calculatedPropertiesOfTypes has the class meta already, if not it uses reflection to get the relevant prop info
                public ObservableObject()
                {
                    Type t = GetType();
                    if (!calculatedPropertiesOfTypes.ContainsKey(t.FullName))
                    {
                        var props = t.GetProperties();
    
                        foreach (var pInfo in props)
                        {
                            var attr = pInfo.GetCustomAttribute<CalculatedProperty>(false);
                            if (attr == null)
                                continue;
    
                            calculatedPropertiesOfTypes[t.FullName] = new Dictionary<string, string[]>();
                            calculatedPropertiesOfTypes[t.FullName][pInfo.Name] = attr.Properties;
                        }
                    }
    
                    if (calculatedPropertiesOfTypes[t.FullName] != null)
                        hasComputedProperties = true;
                    
                }
    
    
                public event PropertyChangedEventHandler PropertyChanged;
                public virtual void OnPropertyChanged(string propertyName)
                {
                    PropertyChangedEventHandler handler = PropertyChanged;
                    if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
                }
    
    
                protected bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
                {
                    //only set the field if there is a new value
                    if (EqualityComparer<T>.Default.Equals(field, value)) 
                        return false;
    
                    field = value;
    
                    OnPropertyChanged(propertyName);
                    
                    if (this.hasComputedProperties)
                    {
                        //check for any computed properties that depend on this property
                        var computedPropNames = 
                            calculatedPropertiesOfTypes[this.GetType().FullName]
                            .Where(kvp => kvp.Value.Contains(propertyName))
                            .Select(kvp => kvp.Key);
    
                        if (computedPropNames != null)
                            if (!computedPropNames.Any())
                                return true;
                        
                        //raise property changed for every computed property that is dependant on the property we did just set
                        foreach (var computedPropName in computedPropNames)
                        {
                            OnPropertyChanged(computedPropName);
                        }
     
                    }
                    return true;
                }
            }
