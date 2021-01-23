    public class Services : IServices
    {
        #region Singleton
        static Services services = null;
        private Services()
        {
        }
        public static Services Instance
        {
            get
            {
                if (services == null)
                {
                    services = new Services();
                }
                return services;
            }
        }
        #endregion
        public IEnumerable<Inventory> LoadParts(int daysFilter)
        {
            return InventoryRepository.Instance.Get(daysFilter);
        }
        public IEnumerable<Warehouse> LoadSupply(Lookup lookup)
        {
            return SupplyRepository.Instance.Get(lookup);
        }
        public IEnumerable<StockAlternative> LoadAlternativeStockCodes()
        {
            return InventoryRepository.Instance.GetAlternatives();
        }
        public IEnumerable<Demand> LoadDemand(IEnumerable<string> stockCodes, int daysFilter, Lookup lookup)
        {
            return DemandRepository.Instance.Get(stockCodes, daysFilter, lookup);
        }
    .
    .
    .
