    public CreditCard this[string input]
    {
        get
        {
            foreach (CreditCard cc in cclist)
            {
                if (cc.Number == input)
                {
                    return cc;
                }
            }
            return null;
        }
    }
