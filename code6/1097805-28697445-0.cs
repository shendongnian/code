            var anon = new { Level = "level", Time = DateTime.Now };
            Type type = anon.GetType();
            var props = type.GetProperties();
            foreach (var propertyInfo in props)
            {
                if (propertyInfo.Name == "Level")
                {
                    var x =propertyInfo.GetValue(anon);
                    
                }
            }
