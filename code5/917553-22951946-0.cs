    class Sheet : ISheet, ISheetWithPartners {
        public IEnumerable<int> RatioIDs { get; set; }
        public IEnumerable<int> PartnerIDs { get; set; }
        public IEnumerable<Partner> Partners { get; set; }
        public double GetRatioAmountForPartner(Partner partner) {
            // Your code here
        }
    }
    interface ISheet {
        IEnumerable<int> RatioIDs { get; }
        IEnumerable<int> PartnerIDs { get; }
    }
    interface ISheetWithPartners {
        IEnumerable<Partner> Partners { get; }
        double GetRatioAmountForPartner(Partner partner);
    }
