    class SampleViewModel
    {
        [Validate]
        public string SomeProperty { get; set; }
        [Validate]
        public string AnotherProperty { get; set; }
        public void Validate()
        {
            foreach (var propertyInfo in GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public).Where(p => p.IsDefined(typeof(ValidateAttribute), true)))
            {
                var value = propertyInfo.GetValue(this, null);
                Validate(value as string);
            }
        }
        private void Validate(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                // do something with the invalid input, i.e. throw the exception
            }
        }
    }
    class ValidateAttribute : Attribute
    {
    }
