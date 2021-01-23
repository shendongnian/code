    public static BindingSource BindingSource
    {
        get
        {
            if (_suppliers == null)
            {
                _suppliers = new BindingList<Classes.Supplier>();
            }
            return new BindingSource(_suppliers, null);
        }
    }
