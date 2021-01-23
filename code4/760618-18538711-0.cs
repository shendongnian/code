    public static void getItems(Object o, List<object> list)
    {
        FieldInfo[] f = new FieldInfo[o.GetType().GetFields().Length];
       f = o.GetType().GetFields();                            
        foreach (FieldInfo fi in f)
        {                    
            if (fi.FieldType.GetFields().Length > 0)
            {
                List<object> newList = new List<object>();
                list.Add(newList);
                getItems(fi, newList);
            }
            else
            {
                list.Add(fi.Name);
            }
        }                                                
    }
