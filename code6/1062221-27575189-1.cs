    [Serializable]
    public class SymitarAccount
    {
        public int PositionalIndex;
        public bool IsClosed{get { return CloseDate.HasValue; }}
        [SymitarInquiryDataFormatAttribute("ID")]
        public int Id;
        [SymitarInquiryDataFormatAttribute("CLOSEDATE")]
        public DateTime? CloseDate;
        [SymitarInquiryDataFormatAttribute("DIVTYPE")]
        public int DivType;
        [SymitarInquiryDataFormatAttribute("BALANCE")]
        public decimal Balance;
        [SymitarInquiryDataFormatAttribute("AVAILABLEBALANCE")]
        public decimal AvailableBalance;
    }
