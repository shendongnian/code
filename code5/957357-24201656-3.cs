    // in class 'Claimant'
    private string m_normalTaxNumber;
    private string ConvertedTaxNumber
    {
        get { return String.IsNullOrEmpty(TaxNumber) ? "0" : TaxNumber; }
    }
    public string NormalTaxNumber
    {
        get
        {
            if (m_normalTaxNumber == null)
            { m_normalTaxNumber = ConvertedTaxNumber; }
            return m_normalTaxNumber;
        }
    }
