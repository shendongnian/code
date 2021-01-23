    var Invoices = GetUnProcessedInvoices();
    Invoices.Where(i=>i.Date > someDate)
          .Do(i=>SendEmail(i.Customer))
          .Do(i=>ShipProduct(i.Customer, i.Product, i.Quamtity))
          .Do(i=>Inventory.Adjust(i.Product, i.Quantity));
