    public class CompanyIndexViewModel
    {
        ...
        public string TaxID { get; set; }
        public string USFormattedTaxID
        {
            get { return Utilities.FormatTaxID(TaxID); }
        }
    }
