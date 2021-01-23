    interface IBasket {
        Guid ID { get; set; } // use for AnonBasketID or UserID depending on implementation
        Guid PackageID { get; set; }
        int PurchasedUnits { get; set; }
    }
