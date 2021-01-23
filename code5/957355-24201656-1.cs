    // in class 'Claimant'
    public void NormalizeTaxNumber()
    {
        if (String.IsNullOrEmpty(TaxNumber))
        { TaxNumber = "0"; }
    }
