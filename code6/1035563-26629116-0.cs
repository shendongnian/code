    const string MY_PROPERTY = "MyProperty";
    public int MyProperty
    {
        get
        {
            if (Session[Home.MY_PROPERTY] == null)
            {
                return 0;
            }
            else
            {
                int iValue = 0;
                if (int.TryParse(Session[Home.MY_PROPERTY].ToString(), out iValue))
                    return iValue;
                else
                    return 0;
            }
        }
        set
        {
            Session[Home.MY_PROPERTY] = value;
        }
    }
