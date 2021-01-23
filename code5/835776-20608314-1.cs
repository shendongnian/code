    var name = (from field in typeof(anEnum).GetFields(
       System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public)
         where field.IsLiteral && (anEnum)field.GetValue(null) == a
         let xa = (System.Xml.Serialization.XmlEnumAttribute)
             Attribute.GetCustomAttribute(field,
             typeof(System.Xml.Serialization.XmlEnumAttribute))
         where xa != null
         select xa.Name).FirstOrDefault();
