    public class GetInfoForAddressAggregate
    {
        private AddressBatch[] _batches;
        public GetInfoForAddressAggregate(Address[] addresses)
        {
            if (addresses.Length >= 5000)
            {
                _batches = SplitIntoBatches(addresses, 5000);
            }
            else
            {
                _batches = SplitIntoBatches(addresses, 1000);
            }
        }
        private AddressBatch[] SplitIntoBatches(Address[] addresses, int size)
        {
            // stubbed method
            return null;
        }
        public void Run()
        {
            foreach (var batch in _batches)
            {
                batch.Run();
            }
        }
        public bool IsComplete
        {
            get { return _batches.All(x => x.IsComplete); }
        }
        private class AddressBatch
        {
            private Address[] _addresses;
            private string _token;
            public string Token
            {
                get { return _token; }
            }
            public AddressBatch(Address[] addresses)
            {
                _addresses = addresses;
            }
            public void Run()
            {
                _token = GetInfoForAddress(_addresses);
            }
            private string GetProgStatus(string token)
            {
                // stubbed method
                return "Complete";
            }
            private string GetInfoForAddress(Address[] addresses)
            {
                // stubbed method
                return "token";
            }
            public bool IsComplete
            {
                get { return _token != null && GetProgStatus(_token) == "Complete"; }
            }
        }
