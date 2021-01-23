    public T DecryptByObject<T>(T myObject, string decryptKey)
    {
        Type t = myObject.GetType();
        PropertyInfo prop = t.GetProperty("Items");
        object list = prop.GetValue(myObject);
        
        foreach (MemberInfo mi in t.GetMembers())
        {
            try
            {
                if (mi.MemberType == MemberTypes.Property)
                {
                    string value = ((PropertyInfo)mi).GetValue(myObject).ToString();
                    var bytes = Convert.FromBase64String(value);
                    var decryValue = MachineKey.Unprotect(bytes, decryptKey);
                    ((FieldInfo)mi).SetValue(myObject, Encoding.UTF8.GetString(decryValue));
                }
            }
            catch (Exception ex) { }
        }
    
        
        return myObject;
    }
