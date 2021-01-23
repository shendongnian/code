    public bool ReadOnly
    {
        get
        {
            return txtBox.ReadOnly;
        }
        set
        {
            txtBox.ReadOnly = value;
            someOtherControl.ReadOnly = value;
            anotherControl.ReadOnly = value;
        }
    }
