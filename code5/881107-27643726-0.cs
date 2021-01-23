        private object HandleListDerivative(object x, XElement root, string propName, Type type)
        {
            Type t;
            if (type.IsGenericType)
            {
                t = type.GetGenericArguments()[0];
            }
            else
            {
                t = type.BaseType.GetGenericArguments()[0];
            }
            var list = (IList)Activator.CreateInstance(type);
            var elements = root.Descendants(t.Name.AsNamespaced(Namespace));
            var name = t.Name;
            
            //add the following
            var attribute = t.GetAttribute<DeserializeAsAttribute>();
            if (attribute != null)
                name = attribute.Name;
