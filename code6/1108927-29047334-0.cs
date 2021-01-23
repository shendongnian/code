    class Customer
    {
        private static PropertyInfo[] _propertyInfos 
            = typeof(Customer).GetProperties()
                              .Where (x => x.Name.StartsWith("A")).ToArray();
        
        public int A1 { get; set; }
        public int A2 { get; set; }
        public int A3 { get; set; }
        
        public int this[int index]
        {
            get
            {
                return (int)(_propertyInfos[index - 1].GetValue(this) ?? 0);
            }
            set
            {
                _propertyInfos[index - 1].SetValue(this, value);
            }
        }
    }
