    public T ValidatingDeserializer<T>(Stream s)
    {
        T deserialize = (T)new XmlSerializer( typeof(T)).Deserialize(s);
        
        foreach(var pi in typeof(T).GetProperties())
        {
            var xmlnull = pi.GetCustomAttribute(typeof(XmlElementAttribute));
            if (xmlnull!=null)
            {   var xmlnullInst = (XmlElementAttribute) xmlnull;
                if (!xmlnullInst.IsNullable && pi.GetValue(deserialize)==null)
                {
                    throw new Exception(String.Format("{0} is null", pi.Name));
                }
            }
        }
        return deserialize;
    }
