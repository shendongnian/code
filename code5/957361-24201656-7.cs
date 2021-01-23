    public class Claimant
    {
        // ...
        public string NormalTaxNumber
        {
            get { return String.IsNullOrEmpty(TaxNumber) ? "0" : TaxNumber; }
        }
    }
