    public class CustomerService : ICustomerService {
      private readonly IInvoiceService _invoiceService = new InvoiceService(this);
      ...
    }
    public class InvoiceService : IInvoiceService {
      
      private readonly ICustomerService _customerService;
      public class InvoiceService(ICustomerService customerService) {
        _customerService = customerService;
      }
    }
