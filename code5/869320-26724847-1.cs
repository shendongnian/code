        public static XmlAttributeOverrides CreateXmlAttributeOverrides(Type type)
        {
            // Tell TypeDescriptor about the buddy class
            TypeDescriptor.AddProvider(new AssociatedMetadataTypeTypeDescriptionProvider(type), type);
            var xmlAttributeOverrides = new XmlAttributeOverrides();
            xmlAttributeOverrides.Add(type, new XmlAttributes(new CustomAttributeProvider(TypeDescriptor.GetAttributes(type))));
            foreach (PropertyDescriptor props in TypeDescriptor.GetProperties(type))
            {
                if (props.Attributes.Count > 0)
                {
                 xmlAttributeOverrides.Add(type, props.Name, new XmlAttributes(new CustomAttributeProvider(props.Attributes)));
                }
            }
            foreach (var field in type.GetFields())
            {
                var attributes = field.GetCustomAttributes(true).OfType<Attribute>().ToArray();
                if (attributes.Any())
                {
                    xmlAttributeOverrides.Add(type, field.Name, new XmlAttributes(new CustomAttributeProvider(attributes)));
                }
            }
            return xmlAttributeOverrides;
        }
    }
