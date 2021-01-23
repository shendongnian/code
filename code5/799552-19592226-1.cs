    public decimal TaxValue 
    {
       get { return _taxValue; }
       set { _taxValue = value; OnPropertyChanged(); }  // Using .Net 4 caller member method.
    }
    
    public decimal Deduction
    {
       get { return _deduction; }
       set { _deduction = value; FigureTax(); }
    }
    
    public decimal Rate
    {
       get { return _rate; }
       set { _rate = value; FigureTax(); }
    }
    
    public decimal Income
    {
       get { return _income; }
       set { _income = value; FigureTax(); }
    }
    
    // Something has changed figure the tax and update the user.
    private void FigureTax()
    {
       TaxValue = (Income - Deduction) * Rate;
    }
