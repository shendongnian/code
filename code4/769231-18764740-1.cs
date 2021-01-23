    private void Register()
    {
        Attribute[] attr = new Attribute[1];
        TypeConverterAttribute vConv = new TypeConverterAttribute(typeof(BindingConverter));
        attr[0] = vConv;
        TypeDescriptor.AddAttributes(typeof(BindingExpression), attr);
    }
