    public void LoadDefaultValues()
    {
       foreach (PropertyInfo p in this.GetType().GetProperties())
       {
           foreach (Attribute attr in p.GetCustomAttributes(true))
           {
               if (attr is DefaultValueAttribute)
               {
                    DefaultValueAttribute dv = (DefaultValueAttribute)attr;
                    p.SetValue(this, dv.Value, null);
               }
            }
        }
    }
