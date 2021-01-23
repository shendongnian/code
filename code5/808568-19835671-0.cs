    public interface IVATFullAccess {
        public decimal VAT { get; set; }
    };
    public interface IVATReader {
        public decimal VAT { get; }
    };
    public class Administrator: IVATFullAccess,... { ... } // has full access to VAT
    public class Donation : IVATReader,...  { ... } // has read-only access to VAT
