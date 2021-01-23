    public class PlayerEquipment
    {
        public string Id
        {
            get { return PlayerId + "/" + ItemId; }
        }
        public int PlayerId { get; set; }
        [References(typeof(ItemData))]
        public int ItemId { get; set; }
        public int Quantity { get; set; }
        public bool IsEquipped { get; set; }
        [Reference]
        public ItemData ItemData { get; set; }
    }
    public class ItemData
    {
        [AutoIncrement]
        public int Id { get; set; }
        public string Data { get; set; }
    }
