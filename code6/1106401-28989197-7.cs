        static void Main(string[] args) {
            IClient _client;
            _client = null;
            var filters = new List<IFilterSetManager>() {
                new CityManager(),
                new ChainManager()
            };
            foreach (var item in filters) {
                var newFilter = item.Initialize(_client);
                System.Console.WriteLine("Filter name: " + newFilter.FilterName);
                System.Console.WriteLine("Filters added: " + newFilter.Filters.Count);
            }
            System.Console.ReadLine();
        }
