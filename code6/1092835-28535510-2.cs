        private static object CloneObject(object o)
        {
            Type t = o.GetType();
            PropertyInfo[] properties = t.GetProperties();
            object p = new InvoiceInput();
            foreach (PropertyInfo pi in properties)
            {
                p.GetType().GetProperty(pi.Name).SetValue(p, pi.GetValue(o, null),null);
            }
            return p;
        }
