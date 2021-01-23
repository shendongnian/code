     public static object ObjectCopyProperties(this object sourceObject, object targetObject)
        {
            if (sourceObject == null || targetObject == null)
                return null;
    
            var targetInstance = targetObject;
            PropertyInfo newProp;
            foreach (PropertyInfo prop in sourceObject.GetType().GetProperties())
            {
                if (prop.CanRead)
                {
                    newProp = targetInstance.GetType().GetProperty(prop.Name);
                    if (newProp != null && newProp.CanWrite)
                    {
                        newProp.SetValue(targetInstance, prop.GetValue(sourceObject, null), null);
                    }
                }
            }
            return targetInstance;
        }
