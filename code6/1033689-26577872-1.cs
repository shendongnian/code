        [Column("VATInclusive")]
        public int _VATInclusive { get; set; }
        [NotMapped]
        public bool VATInclusive
        {
            get
            {
                return Convert.ToBoolean(_VATInclusive);
            }
            set 
            {
                _VATInclusive = value ? 1 : 0;
            }
        }
