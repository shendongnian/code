        [Column("VATInclusive")]
        public int _VATInclusive { get; set; }
        [NotMapped]
        public bool VATInclusive
        {
            get
            {
                return _VATInclusive != 0;
            }
            set 
            {
                _VATInclusive = value ? 1 : 0;
            }
        }
