    public class Basket
    {
        [Key]
        public string BasketID { get; set; }
        public virtual List<BasketItem> BasketItems { get; set; }
        public System.DateTime DateCreated { get; set; }
        public Guid UserId { get; set; }
    
    }
    ...
    var basketItem = storeDb.Basket.Where(basket => basket.UserId == currentUserId)
    .Include(basket => basket.BasketItems ).Where(bi => bi.sellerId == basketItem.sellerID && bi.sku == basketItem.sku);
