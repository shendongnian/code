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
                    //get our 'childs' children - ignoring the first item 
                    var grandChildren = properties.Skip(1);
                    //copy this child object and use it to pass back into this method recusivly - thus creating our nested structure
                    var child = parent.GetType().GetProperty(properties[0]).GetValue(parent, null);
                    //passing in the child object and then its children - which are grandchildren from our parent.
                    ret.Add(properties[0], CreateObject(child, grandChildren.ToList()));
                }
                else //no nested properties just assign the property 
                    ret.Add(property, parent.GetType().GetProperty(property).GetValue(parent));
            }
            return expando;
        }
