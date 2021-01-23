    private static object GetObject(string typeName, string propertyName, XmlNode inputs, Assembly assembly)
        {
            
            var type = assembly.GetExportedTypes().FirstOrDefault(t => t.Name == typeName);
            if (type == null)
                throw new ArgumentException(string.Format("Type {0} is not found.", typeName));
            var obj = Activator.CreateInstance(type);
            var doc = XDocument.Parse(inputs.OuterXml);
           
            foreach (var prop in type.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly | BindingFlags.SetProperty))
            {
                if (!prop.Name.Equals("ExtensionData"))
                { 
                    if (prop.PropertyType.IsPrimitive())
                    {
                        var childNodesPropLst = doc.Descendants(propertyName);
                        foreach (XElement childNodeprop in childNodesPropLst)
                        {
                            XElement childElement = childNodeprop.Element(prop.Name);
                            if (childElement != null)
                            {
                                prop.SetValue(obj, Convert.ChangeType(childElement.Value, prop.PropertyType), null);
                                break;
                            }
                        }
                    }
                    else
                    {
                        // This is done if the return type of the property belongs to the same class name.
                        // Otherwise it goes in a loop.
                        if (prop.PropertyType.Name.Equals(type.Name))
                            break;
                        Object propVal = GetObject(prop.PropertyType.Name, prop.Name, inputs, assembly);
                        prop.SetValue(obj, propVal, null);
                        
                    }
                    //prop.SetValue(obj,childNode,null);
                }
            }
            foreach (var f in type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly | BindingFlags.SetField))
            {
                f.SetValue(obj,
                           f.FieldType.IsPrimitive()
                               ? inputs[propertyName].ChildNodes[0].Value
                               : GetObject(f.FieldType.Name, f.FieldType.Name, inputs, assembly));
            }
            return obj;
        }
