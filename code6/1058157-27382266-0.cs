    public class Supplier
    {
        public int ID {get;set;}
        public int AccountingUnitId {get;set;}
        public string ShortName {get;set;}
        public int AccountNumber {get;set;}
        public string BankAddress {get;set;}
        public string SupplierAddress {get;set;}
        public TermsOfPayment termPayment[] {get;set;}
    }
