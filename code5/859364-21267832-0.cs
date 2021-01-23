    public static void SetMyClass (ref myClass data, ListControl crl) 
    {
        var value = crl.SelectedValue.ToNullableInt();
        if (value.HasValue)
        {
            data = new myClass () { Id = value.Value };
        }
    }
