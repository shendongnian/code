    [ComplexType]
    public class WrappedPhysicalAddress
    {
        [MaxLength( 17 )]
        public string PhysicalAddressString
        {
            get
            {
                return PhysicalAddress == null ? null : PhysicalAddress.ToString();
            }
            set
            {
                PhysicalAddress = value == null ? null : System.Net.NetworkInformation.PhysicalAddress.Parse( value );
            }
        }
        [NotMapped]
        public System.Net.NetworkInformation.PhysicalAddress PhysicalAddress
        {
            get;
            set;
        }
        public static implicit operator string( WrappedPhysicalAddress target )
        {
            return target.ToString();
        }
        public static implicit operator System.Net.NetworkInformation.PhysicalAddress( WrappedPhysicalAddress target )
        {
            return target.PhysicalAddress;
        }
        public static implicit operator WrappedPhysicalAddress( string target )
        {
            return new WrappedPhysicalAddress() 
            { 
                PhysicalAddressString = target 
            };
        }
        public static implicit operator WrappedPhysicalAddress( System.Net.NetworkInformation.PhysicalAddress target )
        {
            return new WrappedPhysicalAddress()
            {
                PhysicalAddress = target
            };
        }
        public override string ToString()
        {
            return PhysicalAddressString;
        }
    }
