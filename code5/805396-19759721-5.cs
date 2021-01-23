    private IEnumerable<Models.DataExport> GetData(DateTime startDate, DateTime endDate)
    {
        using (var db = new DAL.smigEntities())
        {
            CultureInfo deDE = CultureInfo.CreateSpecificCulture("de-DE");
            return db.Order
                .Where(x => x.datecreated >= startDate && x.datecreated <= endDate).AsEnumerable()
                .Join(db.Payment, Order => Order.id, Payment => Payment.orderId, (Order, Payment) => new Models.DataExport
                {
                    Id = Order.id,
                    Product = Order.product,
                    Invoicenr = Order.invoicenr,
                    Quantity = string.Format("{0:0}", Order.amount),
                    Price = string.Format(deDE, "{0:0.00}", Order.price),
                    Shipping = string.Format(deDE, "{0:0.00}", Order.shipping),
                    Vatrate = string.Format(deDE, "{0:0.00}", Order.vatrate),
                    Datecreated = Order.datecreated,
                    Datepaid = Order.datepaid,
                    Dateinvoice = Order.dateinvoice,
                    Paymentrecorddate = Payment.datecreated,
                    Paymentstatus = Payment.PaymentStatus.title,
                    Paymentmethod = Payment.PaymentMethod.title,
                    Paidamount = string.Format(deDE, "{0:0.00}", Payment.amout),
                    Transactionidentifier = Payment.transactionIdentifier,
                    Comment = Payment.comment,
                    Title = Order.Address.title,
                    Name = Order.Address.name,
                    Lastname = Order.Address.lastname,
                    Recepient2 = Order.Address.recepient2,
                    Company = Order.Address.company,
                    Address1 = Order.Address.address1,
                    Address2 = Order.Address.address2,
                    Address3 = Order.Address.address3,
                    Town = Order.Address.town,
                    Postcode = Order.Address.postcode,
                    County = Order.Address.county,
                    Country = Order.Address.country,
                    Email = Order.Customer.email,
                    Balancerelevant = Payment.PaymentStatus.balancerelevant.Value
                })
                .OrderByDescending(x => x.Datecreated).ThenByDescending(x => x.Id).ThenByDescending(x => x.Paymentrecorddate)
                .ToList();
        }
    }
