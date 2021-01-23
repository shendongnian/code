        [Column("VATInclusive")]
        public int _VATInclusive { get; set; }
        [NotMapped]
        public bool VATInclusive
        {
            get
            {
                if (_VATInclusive == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            set 
            {
                _VATInclusive = value ? 1 : 0;
            }
        }
