            foreach (var pi in typeof(T).GetProperties())
            {
                var propertyValue = pi.GetValue(obj); // This is the Dog or Cow object
                var pt = pi.PropertyType;
                
                var nameProperty = pt.GetProperty("Name");
                if (pt.IsClass && nameProperty != null)
                {
                    var name = nameProperty.GetValue(propertyValue); // This pulls the name off of the Dog or Cow
                    Console.WriteLine(name);
                }
            }
