    public class Order
    {
        [PrimaryKey, Identity]
        public int OrderId { get; set; }
        [Column]
        public OrderType Type { get; set; }
        private string _DisplayType;
        [NotMapped]
        public string DisplayType
        {
            get
            {
                if (Type != null)
                    _DisplayType = Type.ToString();
                else
                    _DisplayType = string.Empty;
                return _DisplayType;
            }
            set
            {
                if (_DisplayType != value)
                {
                    _DisplayType = value;
                }
            }
        }
    }
