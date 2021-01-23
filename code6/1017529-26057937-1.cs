    public Form1()
        {
            InitializeComponent();
            Application.EnableVisualStyles();
            var obj = new CustomObjectType
            {
                ObjectName = "CompositeFirst",
                Properties =
                {
                    new CustomProperty { Name = "Property1", Type = typeof(int), Desc = "Property1 desc", DefaultValue = 1, HasDifference = true},
                    new CustomProperty { Name = "Property2", Type = typeof(DateTime), Desc = "Property2 desc"},
                    new CustomProperty { Name = "Property1", Type = typeof(CustomObjectType), HasDifference = true},
                }
            };
            var customObjectType = obj.Properties[2].DefaultValue as CustomObjectType;
            if (customObjectType != null)
                customObjectType.ObjectName = "CompositSecond";
                customObjectType.Properties = new List<CustomProperty>
                {
                    new CustomProperty { Name = "Property4", Type = typeof(int), DefaultValue = 5, HasDifference = true},
                    new CustomProperty { Name = "Property5", Type = typeof(DateTime), Desc = "Property2 desc", DefaultValue = DateTime.Now},
                };
            propertyGrid1.SelectedObject = obj;    
            propertyGrid1.DisabledItemForeColor = Color.Red;
        }
        [TypeConverter(typeof(CustomObjectConverter))]
        public class CustomObjectType : TypeConverter 
        {
            private List<CustomProperty> _props = new List<CustomProperty>();
            [Browsable(false)]
            public string ObjectName
            {
                get;
                set;
            }
            [Browsable(false)]
            public List<CustomProperty> Properties
            {
                get { return _props; }
                set { _props = value; }
            }
            private readonly Dictionary<string, object> values = new Dictionary<string, object>();
            public object this[string name]
            {
                get { object val; values.TryGetValue(name, out val); return val; }
                set { values.Remove(name); }
            }
            private class CustomObjectConverter : ExpandableObjectConverter 
            {
                public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, Attribute[] attributes)
                {
                    var stdProps = base.GetProperties(context, value, attributes);
                    var obj = value as CustomObjectType;
                    var customProps = obj == null ? null : obj.Properties;
                    var props = new PropertyDescriptor[stdProps.Count + (customProps == null ? 0 : customProps.Count)];
                    stdProps.CopyTo(props, 0);
                    if (customProps != null)
                    {
                        int index = stdProps.Count;
                        foreach (CustomProperty prop in customProps)
                        {
                            props[index++] = new CustomPropertyDescriptor(prop);
                        }
                    }
                    return new PropertyDescriptorCollection(props);
                }
                public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
                {
                    if (value is CustomObjectType)
                    {
                        return (value as CustomObjectType).ObjectName;    
                    }
                    return base.ConvertTo(context, culture, value, destinationType);
                }
            }
            private class CustomPropertyDescriptor : PropertyDescriptor
            {
                private readonly CustomProperty _prop;
                public CustomPropertyDescriptor(CustomProperty prop)
                    : base(prop.Name, null)
                {
                    _prop = prop;
                }                
                public override bool IsReadOnly { get { return _prop.HasDifference; } }
                public override string Category { get { return "Main Category"; } }
                public override string Description { get { return _prop.Desc; } }
                public override string Name { get { return _prop.Name; } }
                public override bool ShouldSerializeValue(object component) { return ((CustomObjectType)component)[_prop.Name] != null; }
                public override void ResetValue(object component) { ((CustomObjectType)component)[_prop.Name] = null; }                
                public override Type PropertyType { get { return _prop.Type; } }
                public override bool CanResetValue(object component) { return true; }
                public override Type ComponentType { get { return typeof(CustomObjectType); } }
                public override void SetValue(object component, object value) { ((CustomObjectType)component)[_prop.Name] = value; }
                public override object GetValue(object component) { return ((CustomObjectType)component)[_prop.Name] ?? _prop.DefaultValue; }
            }
        }
        public class CustomProperty
        {
            public string Name { get; set; }
            public string Desc { get; set; }
            public object DefaultValue { get; set; }
            public bool HasDifference { get; set; }
            Type _type;
            public Type Type
            {
                get
                {
                    return _type;
                }
                set
                {
                    _type = value;
                    DefaultValue = Activator.CreateInstance(value);
                }
            }
        }
    }
