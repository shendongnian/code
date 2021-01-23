            Properties p = new Properties();
            Type tClass = p.GetType();
            PropertyInfo[] pClass = tClass.GetProperties();
            int value = 0; // or whatever value you want to set
            foreach (var property in pClass)
            {
                property.SetValue(p, value++, null);
            }
