    static public void CloneObject(object dest, object src)
        {
            Type t = src.GetType();
            PropertyInfo[] properties = t.GetProperties();
    
            foreach (PropertyInfo pi in properties)
            {
                if (pi.CanWrite)
                {
                    pi.SetValue(dest, pi.GetValue(src, null), null);
                }
            }
        }
