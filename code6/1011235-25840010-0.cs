    public string CustomerName
    {
        get
        {
            return customerName;
        }
        set
        {
            if(!(customerName.Equals("")))
            {
                customerName = value;
            }
        }
    }
