            public void EnumerateProperties()
        {
            var propertiesInfo = this.GetType().GetProperties();
            foreach (var propertyInfo in propertiesInfo)
            {
                var val = propertyInfo.GetValue(this, null);
            }
        }
