    public class ConsumableGoodsStock
    {
        //...
        public virtual ConsumableGood ConsumableGood { get; set; }
        public virtual  ICollection<OrderItem> OrderItems { get; set; }
    {
