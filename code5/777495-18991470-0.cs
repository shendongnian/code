    public void MyEntityClass_PropertyFoo_HasRequiredAttribute()
    {
        var prop = typeof(MyEntity).GetProperties().FirstOrDefault(p=>p.Name=="Foo");
        if (prop!=null)
        {
            object[] attributes = prop.GetCustomAttributes(typeof(RequiredAttribute), true);
            if (attributes.Length==0)
            {
               //someone took it out, explode your test here.
            }
        }
    }
