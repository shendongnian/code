    public static XElement ToXml<T>(T obj)
    {
         return new XElement("Properties",
                             from pi in  typeof (T).GetProperties()
                             where !pi.GetIndexParameters().Any() 
                                    && pi.GetCustomAttributes(typeof(XmlIgnoreAttribute), false).Length == 0
                             select new XElement("Property"
                                                 , new XAttribute("Name", pi.Name)
                                                 , pi.GetValue(obj, null))
            );
    }
