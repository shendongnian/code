    public static ExpandoObject CreateObject(object parent, List<string> fields)
        {
            var expando = new ExpandoObject();
            var ret = (IDictionary<string,object>)expando;
            foreach (var property in fields)
            {
                //split to determine if we are a nested property.
                List<string> properties = property.Split('.').ToList();
                if (properties.Count() > 1)
                {
                    var grandChildren = properties.Skip(1);
                    var child = parent.GetType().GetProperty(properties[0]).GetValue(parent, null);
                    //passing in the child object using reflection
                    ret.Add(properties[0], CreateObject(child, grandChildren.ToList()));
                }
                else
                    ret.Add(property, parent.GetType().GetProperty(property).GetValue(parent));
            }
            return expando;
        }
