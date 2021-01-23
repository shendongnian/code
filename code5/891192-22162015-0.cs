    public class InvoiceHeader
    {
       public static explicit operator QBInvoice(InvoiceHeader invoice)
       {
          return new QBInvoice {}; // do your mapping
       }
    }
