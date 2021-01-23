    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
        class TestAttribute : Attribute
        {
            public string Value { get; set; }
        }
        
        [Test(Value = "Hello")]
        public string MyTestProperty
        {
            get
            {
                var typeInfo = GetType();
                // Get the PropertyInfo descriptor for this property
                var propInfo = typeInfo.GetProperty("MyTestProperty");
                
                // Get custom attributes applied to the property
                var attr = propInfo.GetCustomAttributes(false).OfType<TestAttribute>().FirstOrDefault();
                
                // If we have an attribute, then return its Value
                return attr != null ? attr.Value : "No Attribute";
            }
        }
