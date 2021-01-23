    public class Client
    {
        public DomainObjects.FullAddress FullAddress { get; set; }
        public string AddessLine
        {
            get
            {
                return Address();
            }
        }
        private string Address()
        {
            string address = string.Empty;
            address += !string.IsNullOrEmpty(FullAddress.Address) ? FullAddress.Address + ", " : string.Empty;
            address += !string.IsNullOrEmpty(FullAddress.Address) ? FullAddress.Address2 + ", " : string.Empty;
            address += !string.IsNullOrEmpty(FullAddress.Address) ? FullAddress.Town + ", " : string.Empty;
            return address;
        }
    }
