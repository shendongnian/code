    public class ItemSerialModel : TrackableBaseModel<ItemSerial>
    {
        public Int32 ItemSerialId { get; set; }
        [ForeignKey("Item")]
        public Int32? ItemId { get; set; }
        public virtual ItemModel Item {get;set; }
     }
