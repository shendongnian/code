        protected override void PerformValidation(string propertyName = null)
        {
            if (string.IsNullOrEmpty(propertyName) || propertyName == "Property1")
            { }
            else if (string.IsNullOrEmpty(propertyName) || propertyName == "Property2")
            { }
            //...
        }
