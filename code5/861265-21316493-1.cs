    private void getProperties(Object obj, ListBox listBox1)
    {
        PropertyInfo[] pi = obj.GetType().GetProperties();
        foreach (PropertyInfo p in pi)
        {
            if (p.PropertyType.IsGenericType)
            {
                object o = p.GetValue(obj, null);
                if (o != null)
                {
                    if (o is Address)
                        getProperties(o, listBox1);
                    else
                        listBox1.Items.Add(o.ToString());
                }
            }
        }
    }
