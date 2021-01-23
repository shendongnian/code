    public static class ReflectionExtensions
    {
        public static void CopyPropertiesFrom(this object destObject, object sourceObject)
        {
            if (null == destObject)
                throw new ArgumentNullException("destObject");
            if (null == sourceObject)
                throw new ArgumentNullException("sourceObject");
            Type destObjectType = destObject.GetType();
            foreach (PropertyInfo sourcePi in sourceObject.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public))
            {
                PropertyInfo destPi = destObjectType.GetProperty(sourcePi.Name);
                if (null != destPi && null != destPi.SetMethod)
                {
                    object sourcePropertyValue = sourcePi.GetValue(sourceObject);
                    destPi.SetValue(destObject, sourcePropertyValue);
                }
            }
        }
    }
