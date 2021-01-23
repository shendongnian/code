        [Column("PhysicalAddress")]
        [MaxLength(17)]
        protected string PhysicalAddressString
        {
            get
            {
                return PhysicalAddress.ToString();
            }
            set
            {
                PhysicalAddress = System.Net.NetworkInformation.PhysicalAddress.Parse( value );
            }
        }
        [NotMapped]
        public System.Net.NetworkInformation.PhysicalAddress PhysicalAddress
        {
            get;
            set;
        }
