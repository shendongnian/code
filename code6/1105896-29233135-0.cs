    public interface IServices
    {
        IEnumerable<Warehouse> LoadSupply(Lookup lookup);
        IEnumerable<Demand> LoadDemand(IEnumerable<string> stockCodes, int daysFilter, Lookup lookup);
        
        IEnumerable<Inventory> LoadParts(int daysFilter);
        Narration LoadNarration(string stockCode);
        IEnumerable<PurchaseHistory> LoadPurchaseHistory(string stockCode);
        IEnumerable<StockAlternative> LoadAlternativeStockCodes();
        AdditionalInfo GetSupplier(string stockCode);
    }
