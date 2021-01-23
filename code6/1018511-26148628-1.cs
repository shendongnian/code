    public ActionResult AddProduct(List<Product> products)
    {
    //var acc = Account.FetchAccountFromIdentity(User.Identity.GetUserName());
    var username = User.Identity.GetUserName();
    var acc = db.Accounts.First(u => u.EmailAddress == username);
    var payment = new Payment();
    foreach (var product in products)
    {
        if (product.IsSelected)
        {
            var tempProduct = db.Products.Find(product.ProductID);
            payment.Products.Add(tempProduct);
            payment.PaymentStatus = enPaymentStatus.Pending;
            payment.Gross += tempProduct.Price;
            payment.Vat += tempProduct.Price * 0.2;
            payment.Net += payment.Gross - payment.Vat;
         }
    }
    payment.AccountID = acc.AccountID;
    db.Payments.Add(payment);
    db.SaveChanges();
    return RedirectToAction("Pay", "Products", new {id = acc.AccountID} );
    }
