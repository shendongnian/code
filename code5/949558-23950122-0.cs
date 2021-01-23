    public void X()
    {
        A(null);
    }
    public void A(Action<ColumnView, bool> a)
    {
        if (a != null)
        {
            a();
        }
    }
