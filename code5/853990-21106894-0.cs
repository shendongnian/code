    public class PhoneRecordVM
    {
        public ICollection<CellPhoneCarrier> CellPhoneCarriers { get; set; }
        
        public PhoneRecordVM(Customer customer)
        {
            CellPhoneCarriers = (db.CellPhoneCarrier)
                .Where(e => e.CarrierZone == customer.Zone)
                .OrderBy(e => e.CellPhoneCarrier.Text))
                .ToList();
        }
    }
