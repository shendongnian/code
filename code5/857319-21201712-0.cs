    public class CustomerInvoicer {
        private readonly ICustomerService _customerService;
        private readonly IInvoiceService _invoiceService;
        public CustomerInvoicer(ICustomerService cust, IInvoiceService inv) {
            _invoiceService = inv;
            _customerService = cust;
        }
        public Customer GetInvoiceCustomer(int invoiceId) {
            Invoice invoice = _invoiceService.GetInvoiceById(invoiceId);
            return _customerService.GetCustomerById(invoice.CustomerId);
        }
    }
        
