        PropertyInfo[] pi = person.GetType().GetProperties();
        foreach (PropertyInfo p in pi)
        {
            if (p.PropertyType.IsGenericType)
            {
                object o = p.GetValue(person, null);
                if (o != null) listBox1.Items.Add(o.ToString());
            }
        }
