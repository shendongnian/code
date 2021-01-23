     PropertyInfo[] properties = typeof(DoctorInfo).GetProperties();
                foreach (PropertyInfo prop in properties)
                {
                    object[] attrs = prop.GetCustomAttributes(true);
    
                    foreach (object attr in attrs)
                    {
                        DisplayNameAttribute displayName = attr as DisplayNameAttribute;
                        if (displayName != null)
                        {
                           var attributeName = displayName.DisplayName; // check if this matches what you want
                        string propertyName = prop.Name;                        }
                    }
                }
