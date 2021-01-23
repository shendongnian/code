    class MyClass
    {
        public string FirstName { private get; set; }
        public string LastName { private get; set; }
        public string GetModifiedValue(string propertyName)
        {
            var prop = this.GetType().GetProperty(propertyName);
            return ModifyStringMethod((string)prop.GetValue(this, null));
        }
    }
