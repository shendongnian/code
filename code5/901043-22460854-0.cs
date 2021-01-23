    var query = from contact in contacts
        group contact by contact.RegisterDate into contactGroup
        join purchase in purchases
        on contactGroup.Key equals purchase.PurchaseDate into purchaseGroup
        select new StatusData
        {
            Date = contactGroup.Key,
            RegisteredUsers = contactGroup.Count(),
            Orders = purchaseGroup.Count(),
            Import = purchaseGroup.Sum(p => p.Import),
            
        };
