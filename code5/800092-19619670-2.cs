    public int MyProperty 
    { 
        get
        {
            int myProperty = 0;
            if (ViewState["MyProperty"] != null)
            {
                int.TryParse(ViewState["MyProperty"].ToString(), out myProperty);
            }
            return myProperty;
        } 
        set
        {
            ViewState["MyProperty"] = value;
        }
    }
