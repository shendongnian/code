    public void doit(string method)
    {          
        foreach (var prop in this.GetType().GetFields())
        {
            // Get the method by name
            var meth = prop.FieldType.GetMethod(method);
            if (meth != null)
            {
                meth.Invoke(prop.GetValue(this), null);
            }
        }
    }
