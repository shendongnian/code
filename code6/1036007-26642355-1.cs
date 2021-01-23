    public void Do(Base b, bool xyz, bool currentValueImProcessing)
    {
        if (xyz)
        {
            b.DoThisA  = currentValueImProcessing;
        }
        else
        {
            b.DoThisB  = currentValueImProcessing;
        }
    }
