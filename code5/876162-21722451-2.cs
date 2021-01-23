     foreach (PropertyInfo propertyInfo in type.GetProperties())
            {
                object[] attrObjs = propertyInfo.GetCustomAttributes(typeof(ExampleAttribute), true);
                if (attrObjs.Length > 0)
                {
                 }
             }
