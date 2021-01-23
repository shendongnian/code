    var contacts = new List<Contact>();
    var purchases = new List<Purchase>();
    var dates = contacts.Select(x => x.RegisterDate.Value)
                        .Concat(purchases.Select(x => x.PurchaseDate.Value))
                        .Distinct();
    var data = from date in dates
               join c in contacts on date equals c.RegisterDate.Value into registered
               join p in purchases on date equals p.PurchaseDate.Value into purchased
               select new StatusData {
                   Date = date,
                   RegisteredUsers = registered.Count(),
                   Orders = purchases.Count(),
                   Import = purchases.Sum(x => x.Import)
               };
